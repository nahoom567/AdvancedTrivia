#pragma once
#include "IRequestHandler.h"
#include "Managers/Game/GameManager.h"
#include "server/Infrastructure/RequestHandlerFactory.h"
#include "json/JsonResponsePacketSerializer.h"
#include "RequestResult.h"

class RequestHandlerFactory;


class GameRequestHandler :
    public IRequestHandler
{
public:
	GameRequestHandler(Game& game, LoggedUser& logUser, GameManager& gm, RequestHandlerFactory& handlerFactory);
	bool isRequestRelevant(const RequestInfo& reqInfo);
	RequestResult handleRequest(const RequestInfo& reqInfo);
	RequestResult getQuestion(RequestInfo reqInfo);
	RequestResult submitAnswer(RequestInfo reqInfo);
	RequestResult getGameResults(RequestInfo reqInfo);
	RequestResult leaveGame(RequestInfo reqInfo);
	RequestResult startGame(RequestInfo reqInfo);

private:
	Game& m_game;
	LoggedUser m_user;
	GameManager& m_gameManager;
	RequestHandlerFactory& m_handlerFactory;
};

