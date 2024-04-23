#include "pch.h"
#include "MenuRequestHandler.h"
#include "RequestResult.h"

MenuRequestHandler::MenuRequestHandler(const LoggedUser& logUser, RequestHandlerFactory& handlerFactory) : m_user(logUser), m_handlerFactory(handlerFactory)
{

}


bool MenuRequestHandler::isRequestRelevant(const RequestInfo& reqInfo)
{
	return (reqInfo.id == RequestCode::createRoom || reqInfo.id == RequestCode::getRooms ||
		reqInfo.id == RequestCode::getPlayers || reqInfo.id == RequestCode::joinRoom ||
		reqInfo.id == RequestCode::getPersonalScore || reqInfo.id == RequestCode::getHighScore ||
		reqInfo.id == RequestCode::logout);
}


RequestResult MenuRequestHandler::handleRequest(const RequestInfo& reqInfo)
{
	switch (reqInfo.id)
	{
	case RequestCode::createRoom:
		return handleCreateRoom(reqInfo.buffer);
	case RequestCode::getRooms:
		return handleGetRooms();
	case RequestCode::getPlayers:
		return handleGetPlayers(reqInfo.buffer);
	case RequestCode::joinRoom:
		return handleJoinRoom(reqInfo.buffer);
	case RequestCode::logout:
		return handleLogout();
	case RequestCode::getHighScore:
		return handleGetHighScore();
	case RequestCode::getPersonalScore:
		handleGetPersonalScore();
	}
}

RequestResult MenuRequestHandler::handleCreateRoom(const std::vector<unsigned char>& buffer)
{
	static int roomId = 1;
	int responseStatus = 0;
	IRequestHandler* requestHandler = this;

	CreateRoomRequest crRoomRequest = JsonResponsePacketDeserializer::deserializeCreateRoomRequest(buffer);
	bool res = m_handlerFactory.getRoomManager().createRoom(m_user,
		RoomData(crRoomRequest.roomName, crRoomRequest.maxUsers,
			crRoomRequest.questionCount, crRoomRequest.answerTimeout,
			roomId));
	

	// if the creation of the room was successful than it will increase the id of the room for the next time:
	if (res)
	{
		responseStatus = roomId; // the status will be the room id in the case that the process succeeded 

		requestHandler = m_handlerFactory.createRoomAdminRequestHandler(
			m_user, m_handlerFactory.getRoomManager().getRoom(roomId));
		roomId++;
	}

	return RequestResult(JsonResponsePacketSerializer::serializeResponse(CreateRoomResponse(responseStatus)), requestHandler);
}

inline RequestResult MenuRequestHandler::handleGetRooms()
{
	return RequestResult(JsonResponsePacketSerializer::serializeResponse(
		GetRoomsResponse(SUCCESS_STATUS, m_handlerFactory.getRoomManager().getRooms())), this);
}

inline RequestResult MenuRequestHandler::handleGetPlayers(const std::vector<unsigned char>& buffer)
{
	GetPlayersInRoomRequest getPlayers = JsonResponsePacketDeserializer::deserializeGetPlayersRequest(buffer);
	std::vector<std::string> players = m_handlerFactory.getRoomManager().getRoom(getPlayers.roomId).getAllUsers();

	return RequestResult(JsonResponsePacketSerializer::serializeResponse(GetPlayersInRoomResponse(players)), this);
}

inline RequestResult MenuRequestHandler::handleJoinRoom(const std::vector<unsigned char>& buffer)
{
	JoinRoomRequest roomReq = JsonResponsePacketDeserializer::deserializeJoinRoomRequest(buffer);
	IRequestHandler* handleRequest = this;
	bool res = true;
	try
	{
		m_handlerFactory.getRoomManager().getRoom(roomReq.roomId).addUser(m_user);
	}
	catch (const std::invalid_argument& e)
	{
		std::cout << e.what() << std::endl;
		res = false;
	}

	// to make sure we deleting the old request;
	if (res)
	{
		handleRequest = m_handlerFactory.createRoomMemberRequestHandler(m_user, 
			m_handlerFactory.getRoomManager().getRoom(roomReq.roomId));
		// delete this;
	}
	return RequestResult(JsonResponsePacketSerializer::serializeResponse(JoinRoomResponse(res)), handleRequest);
}

inline RequestResult MenuRequestHandler::handleLogout()
{
	bool succ = this->m_handlerFactory.getLoginManager().logout(m_user.getUsername());
	return RequestResult(JsonResponsePacketSerializer::serializeResponse(LogoutResponse(succ)), m_handlerFactory.createLoginRequestHandler());
}

inline RequestResult MenuRequestHandler::handleGetHighScore()
{
	std::vector<std::string> highScores;
	bool res = true;
	try
	{
		highScores = m_handlerFactory.getStatisticsManager().getHighScores();
	}
	catch (const std::invalid_argument& e)
	{
		std::cout << e.what() << std::endl;
		res = false;
	}
	return RequestResult(JsonResponsePacketSerializer::serializeResponse(getHighScoreResponse(1, highScores)), this);
}

inline RequestResult MenuRequestHandler::handleGetPersonalScore()
{
	std::vector<std::string> userStats;
	bool res = true;
	try
	{
		userStats = m_handlerFactory.getStatisticsManager().getUserStatistics(m_user.getUsername());
	}
	catch (const std::invalid_argument& e)
	{
		std::cout << e.what() << std::endl;
		res = false;
	}
	return RequestResult(JsonResponsePacketSerializer::serializeResponse(getPersonalStatsResponse(res, userStats)), this);
}
