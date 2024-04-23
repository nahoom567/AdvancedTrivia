#pragma once
#include "IRequestHandler.h"
#include "Managers/Login/LoginManager.h"
#include "server/Infrastructure/RequestHandlerFactory.h"
#include "json/JsonResponsePacketSerializer.h"
#include "json/JsonRequestPacketDeserializer.h"

class RequestHandlerFactory;

class MenuRequestHandler : public IRequestHandler
{
public:
	MenuRequestHandler(const LoggedUser& logUser, RequestHandlerFactory& handlerFactory);
	bool isRequestRelevant(const RequestInfo& reqInfo);
	RequestResult handleRequest(const RequestInfo& reqInfo);

private:
	inline RequestResult handleCreateRoom(const std::vector<unsigned char>& buffer);
	inline RequestResult handleGetRooms();
	inline RequestResult handleGetPlayers(const std::vector<unsigned char>& buffer);
	inline RequestResult handleJoinRoom(const std::vector<unsigned char>& buffer);
	inline RequestResult handleLogout();
	inline RequestResult handleGetHighScore();
	inline RequestResult handleGetPersonalScore();

	LoggedUser m_user;
	RequestHandlerFactory& m_handlerFactory;
};

