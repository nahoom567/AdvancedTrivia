#pragma once
#include "IRequestHandler.h"
#include "Managers/Room/Room.h"
#include "Managers/Login/LoggedUser.h"
#include "Managers/Room/RoomManager.h"
#include "server/Infrastructure/RequestHandlerFactory.h"

class RequestHandlerFactory;

class RoomMemberRequestHandler : public IRequestHandler
{
public:
    RoomMemberRequestHandler(unsigned int roomId, const LoggedUser& logUser, RoomManager& roomManager,
        RequestHandlerFactory& handlerFact);
    bool isRequestRelevant(const RequestInfo& reqInfo);
    RequestResult handleRequest(const RequestInfo& reqInfo);
    
private:
    inline RequestResult leaveRoom();
    inline RequestResult getRoomState();
    inline RequestResult roomGotClosed(const std::vector<uint8_t>& buffer);

    Room& m_room;
    LoggedUser m_user;
    RoomManager& m_roomManager;
    RequestHandlerFactory& m_handlerFactory;
    unsigned int m_roomId;
};

