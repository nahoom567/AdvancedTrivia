#pragma once
#include "server/Handles/IRequestHandler.h"
#include "Managers/Room/Room.h"
#include "Managers/Room/RoomManager.h"
#include "server/Infrastructure/RequestHandlerFactory.h"

#define ROOM_WAITING_STATE 1
#define ROOM_GAME_STARTED 2
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
	inline RequestResult startGame(const RequestInfo& reqInfo);
	inline RequestResult getRoomState();

	Room& m_room;
	LoggedUser m_user;
	RoomManager& m_roomManager;
	RequestHandlerFactory& m_handlerFactory;
	unsigned int m_roomId;
};

