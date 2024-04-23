#include "pch.h"
#include "GameRequestHandler.h"


GameRequestHandler::GameRequestHandler(Game& game, LoggedUser& logUser, GameManager& gm, RequestHandlerFactory& handlerFactory) : m_game(game), m_user(logUser), m_gameManager(gm), m_handlerFactory(handlerFactory)
{
}

bool GameRequestHandler::isRequestRelevant(const RequestInfo& reqInfo)
{
	return RequestCode::leaveGame == reqInfo.id || RequestCode::getQuestions == reqInfo.id || RequestCode::submitAnswers == reqInfo.id || RequestCode::getGameResults == reqInfo.id;
}

RequestResult GameRequestHandler::handleRequest(const RequestInfo& reqInfo)
{
	switch (reqInfo.id)
	{
	case RequestCode::leaveGame:
		return leaveGame(reqInfo);
	case RequestCode::getQuestions:
		return getQuestion(reqInfo);
	case RequestCode::submitAnswers:
		return submitAnswer(reqInfo);
	case RequestCode::getGameResults:
		return getGameResults(reqInfo);
	case RequestCode::startGame:
		return startGame(reqInfo);
	}
}

RequestResult GameRequestHandler::getQuestion(RequestInfo reqInfo)
{
	std::map<unsigned int, std::string> answers;
	int i = 1;
	for (auto& ans : m_game.getQuestionForUser(m_user).getPossibleAnswers())
	{
		answers.emplace(i, ans);
		i++;
	}
	std::vector<unsigned char> getQue = JsonResponsePacketSerializer::serializeResponse(GetQuestionResponse(1, m_game.getQuestionForUser(m_user).getQuestion(), answers));
	return RequestResult(getQue, this);
}

RequestResult GameRequestHandler::submitAnswer(RequestInfo reqInfo)
{
	SubmitAnswerRequest subReq = JsonResponsePacketDeserializer::deserializeSubminAnswerRequest(reqInfo.buffer);
	m_game.submitAnswer(m_user, subReq.answerId);
	return RequestResult(JsonResponsePacketSerializer::serializeResponse(SubmitAnswerResponse(1, 
		m_game.getQuestionForUser(m_user).getCorrectAnswerId())), this);
}

RequestResult GameRequestHandler::getGameResults(RequestInfo reqInfo)
{
	std::vector<PlayerResults> playerResults = std::vector<PlayerResults>();
	for (auto& player : m_game.getPlayers())
	{
		playerResults.push_back(PlayerResults(player.first.getUsername(), player.second.correctAnswerCount, player.second.wrongAnswerCount, player.second.averangeAnswerTime));
	}

	return RequestResult(JsonResponsePacketSerializer::serializeResponse(GetGameResultsResponse(1, playerResults)), this);
}

RequestResult GameRequestHandler::leaveGame(RequestInfo reqInfo)
{
	m_game.removePlayer(m_user);
	return RequestResult(JsonResponsePacketSerializer::serializeResponse(LeaveGameResponse(1)), this);
}

RequestResult GameRequestHandler::startGame(RequestInfo reqInfo)
{
	if (m_game.getGameId() == (int)reqInfo.buffer[0])
	{
		return RequestResult(JsonResponsePacketSerializer::serializeResponse(StartGameResponse(1)), this);
	}

	return RequestResult(JsonResponsePacketSerializer::serializeResponse(ErrorResponse("this user is not in the requested game")), this);
}
