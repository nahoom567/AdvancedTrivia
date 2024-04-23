#pragma once
#include "server/Handles/IRequestHandler.h"
#include "Managers/Room/Room.h"
#include "Managers/Room/RoomManager.h"
#include "server/Infrastructure/RequestHandlerFactory.h"

class RequestHandlerFactory;

class RoomAdminRequestHandler : public IRequestHandler
{
public:
	RoomAdminRequestHandler(unsigned int roomId , const LoggedUser& logUser, RoomManager& roomManager,
		RequestHandlerFactory& handlerFact);
	bool isRequestRelevant(const RequestInfo& reqInfo);
	RequestResult handleRequest(const RequestInfo& reqInfo);

private:
	inline RequestResult closeRoom();
	inline RequestResult startGame();
	inline RequestResult getRoomState();

	Room& m_room;
	LoggedUser m_user;
	RoomManager& m_roomManager;
	RequestHandlerFactory& m_handlerFactory;
	unsigned int m_roomId;
};

