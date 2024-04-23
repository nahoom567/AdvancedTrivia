#pragma once
#include "pch.h"
#include "server/Handles/IRequestHandler.h"
#include "server/Handles/RequestResult.h"
#include "server/Infrastructure/RequestHandlerFactory.h"
#define PORT 7348
#define ROOM_NOT_ACTIVE 0

#define requestHandler m_clients[socket]
class Communicator
{
public:
    Communicator(bool& stop);
    ~Communicator();
    void startHandleRequest();

    std::thread clientThread(const SOCKET& clientSocket)
    {
        return std::thread([=] { handleNewClient(clientSocket); });
    }
    std::thread acceptThread()
    {
        return std::thread([=] { acceptClient(); });
    }
private:
    void bindAndListen();
    void handleNewClient(const SOCKET& socket);
    inline void handleClientInput(const SOCKET& socket);
    inline void roomGotClosed(RequestInfo& rInfo, int roomId);
    void startGame(RequestInfo& rInfo, const int gameId);
    void acceptClient();
    /// <summary>
    /// the function is checking if there is a client that is ready to establish a connection 
    /// </summary>
    /// <returns>if there is a client that is ready or not</returns>
    bool clientReady(const SOCKET& socket) const;
    void sendData(const SOCKET sc, char* message, int size);
    char* getPartFromSocket(const SOCKET sc, const int bytesNum, const int flags);

    SOCKET m_serverSocket;
    // changed IRequestHandler to IRequestHandler* because you cannot create an object of an abstract class directly, but you can still use pointers
    std::map<SOCKET, IRequestHandler*> m_clients;
    bool& m_stopServer;
    RequestHandlerFactory& m_handlerFactory;
};
