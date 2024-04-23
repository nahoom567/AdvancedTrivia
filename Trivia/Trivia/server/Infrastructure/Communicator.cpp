#include "pch.h"
#include "Communicator.h"
#include "server/Handles/LoginRequestHandler.h"
#include "json/JsonResponsePacketSerializer.h"
#include "json/JsonRequestPacketDeserializer.h"


Communicator::Communicator(bool& stop) : m_handlerFactory(*(new RequestHandlerFactory(new SqliteDatabase("database")))), m_stopServer(stop)
{

}

Communicator::~Communicator()
{
	for (auto pair : m_clients)
	{
		closesocket(pair.first);
		delete pair.second;
	}

	delete& m_handlerFactory;
}

void Communicator::startHandleRequest()
{
	bindAndListen();
}

void Communicator::bindAndListen()
{
	m_serverSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);

	if (m_serverSocket == INVALID_SOCKET)
		throw std::exception(__FUNCTION__ " - socket");

	struct sockaddr_in sa = { 0 };
	sa.sin_port = htons(PORT); // port that server will listen for
	sa.sin_family = AF_INET;   // must be AF_INET
	sa.sin_addr.s_addr = INADDR_ANY;    // when there are few ip's for the machine. We will use always "INADDR_ANY"


	// Connects between the socket and the configuration (port and etc..)
	if (bind(m_serverSocket, (struct sockaddr*)&sa, sizeof(sa)) == SOCKET_ERROR)
		throw std::exception(__FUNCTION__ " - bind");
	std::cout << "binded..." << std::endl;
	// Start listening for incoming requests of clients
	if (listen(m_serverSocket, SOMAXCONN) == SOCKET_ERROR)
		throw std::exception(__FUNCTION__ " - listen");
	std::cout << "listening..." << std::endl;

	acceptClient();

}

void Communicator::acceptClient()
{
	std::vector<std::thread> threadVect;
	// this accepts the client and create a specific socket from server to this client
	// the process will not continue until a client connects to the server
	while (!m_stopServer)
	{
		if (clientReady(m_serverSocket))
		{
			SOCKET client_socket = accept(m_serverSocket, NULL, NULL);
			if (client_socket == INVALID_SOCKET)
				throw std::exception(__FUNCTION__);
			threadVect.emplace_back(this->clientThread(client_socket));
		}
	}

	for (auto& thread : threadVect)
	{
		thread.join();
	}
}

void Communicator::handleNewClient(const SOCKET& socket)
{
	static int count = 0;
	count++;
	std::cout << "New client connected[" << count << ']' << std::endl;

	// making the LoginRequestHandler the current handler:
	m_clients.insert(std::pair<SOCKET, LoginRequestHandler*>(socket, 
		m_handlerFactory.createLoginRequestHandler()));

	while (!m_stopServer)
	{
		// make it so waiting and checking if there is msg from the user and if there is not than making the check if the server needs to be closed
		u_long nonBlocking = 1;
		ioctlsocket(socket, FIONBIO, &nonBlocking);
		char buffer[1];
		int bytesRead = recv(socket, buffer, sizeof(buffer), MSG_PEEK);
		int error = WSAGetLastError();

		// going to the if there is something to take from the client
		if (!(bytesRead == 0 || (bytesRead == -1 && (error != EWOULDBLOCK && error != EAGAIN))))
		{
			u_long blocking = 0;
			ioctlsocket(socket, FIONBIO, &blocking);

			try
			{
				handleClientInput(socket);
			}
			catch(std::exception e)
			{
				e.what();
			}
		}
	}
	std::cout << "The client disconnected[" << count << ']' << std::endl;
}

void Communicator::handleClientInput(const SOCKET& socket)
{
	static std::list<IRequestHandler*> requestList;
	
	std::vector<uint8_t> vec_responseToUser;
	char* char_responseToUser = nullptr;
	
	// getting code form user
	int code = (int)getPartFromSocket(socket, 1, 0)[0];
	// getting length of message 
	int lenMsg = t_helper::fourBytetoInt((char*)(getPartFromSocket(socket, 4, 0)));
	// getting message according to length
	std::string message = getPartFromSocket(socket, lenMsg, 0);

	// making the buffer
	std::vector<unsigned char> buffer(message.begin(), message.end());

	// creating the request info:
	RequestInfo rInfo = RequestInfo(code, std::time(nullptr), buffer);

	if (requestHandler->isRequestRelevant(rInfo))
	{
		RequestResult rResult = requestHandler->handleRequest(rInfo);
		vec_responseToUser = rResult._response;

		if (rResult._newHandler != requestHandler)
		{
			delete requestHandler;
			requestHandler = rResult._newHandler;
		}
	}
	else
	{
		vec_responseToUser = JsonResponsePacketSerializer::serializeResponse(ErrorResponse("failed to proccess request"));
	}

	char_responseToUser = t_helper::vectToChar(vec_responseToUser);
	sendData(socket, char_responseToUser, vec_responseToUser.size());
	delete char_responseToUser;
}

void Communicator::roomGotClosed(RequestInfo& rInfo, int roomId)
{
	rInfo.buffer = std::vector<uint8_t>(static_cast<uint8_t>(roomId));
	char* responseToUser = nullptr;

	// sending to all of the members of this room a LeaveRoomResponse
	for (auto& [socket, requestHandle] : m_clients)
	{
		RoomMemberRequestHandler* memPtr = dynamic_cast<RoomMemberRequestHandler*>(requestHandle);
		if (!memPtr)
		{
			continue;
		}

		RequestResult rResult = memPtr->handleRequest(rInfo);
		requestHandle = rResult._newHandler;

		responseToUser = t_helper::vectToChar(rResult._response);
		sendData(socket, responseToUser, rResult._response.size());
		delete responseToUser;
	}
}

void Communicator::startGame(RequestInfo& rInfo, const int gameId)
{
	rInfo.buffer = std::vector<uint8_t>(static_cast<uint8_t>(gameId));
	char* responseToUser = nullptr;

	// sending to all of the members of this room a startGameResponse
	for (auto& [socket, requestHandle] : m_clients)
	{
		RoomMemberRequestHandler* memPtr = dynamic_cast<RoomMemberRequestHandler*>(requestHandle);
		if (!memPtr)
		{
			continue;
		}

		RequestResult rResult = memPtr->handleRequest(rInfo);
		requestHandle = rResult._newHandler;

		responseToUser = t_helper::vectToChar(rResult._response);
		sendData(socket, responseToUser, rResult._response.size());
		delete responseToUser;
	}
}


bool Communicator::clientReady(const SOCKET& socket) const
{
	fd_set readSet;
	FD_ZERO(&readSet);
	FD_SET(socket, &readSet);

	timeval timeout;
	timeout.tv_sec = 1;
	timeout.tv_usec = 0;

	int readySockets = select(socket + 1, &readSet, nullptr, nullptr, &timeout);
	return (readySockets > 0);
}

void Communicator::sendData(const SOCKET sc, char* message, int size)
{
	if (send(sc, message, size, 0) == INVALID_SOCKET)
	{
		throw std::exception("Error while sending message to client");
	}
}

char* Communicator::getPartFromSocket(const SOCKET sc, const int bytesNum, const int flags)
{
	char* data = new char[bytesNum + 1];
	data[bytesNum] = 0;
	if (bytesNum == 0)
	{
		return data;
	}


	int res = recv(sc, data, bytesNum, flags);
	if (res == INVALID_SOCKET)
	{
		std::string s = "Error while recieving from socket: ";
		s += std::to_string(sc);
		throw std::exception(s.c_str());
	}
	return data;
}