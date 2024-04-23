#pragma once
#include "Managers/Login/LoginManager.h"
#include "server/Handles/LoginRequestHandler.h"
#include "server/Handles/MenuRequestHandler.h"
#include "Managers/Statistics/StatisticsManager.h"
#include "Managers/Room/RoomManager.h"
#include "server/Handles/RoomAdminRequestHandler.h"
#include "server/Handles/RoomMemberRequestHandler.h"
#include "Managers/Login/LoggedUser.h"

class LoginRequestHandler;
class MenuRequestHandler;
class RoomAdminRequestHandler;
class RoomMemberRequestHandler;

class RequestHandlerFactory
{
public:
	RequestHandlerFactory(IDataBase* database);
	~RequestHandlerFactory();
	LoginRequestHandler* createLoginRequestHandler();
	LoginManager& getLoginManager();
	MenuRequestHandler* createMenuRequestFactory(const LoggedUser& logUser);
	StatisticsManager& getStatisticsManager();
	RoomManager& getRoomManager();
	RoomAdminRequestHandler* createRoomAdminRequestHandler(const LoggedUser& logUser, const Room& room);
	RoomMemberRequestHandler* createRoomMemberRequestHandler(const LoggedUser& logUser, const Room& room);

private:
	IDataBase* m_database;
	LoginManager m_loginManager;
	StatisticsManager m_statsManager;
	RoomManager m_roomManager;
};

