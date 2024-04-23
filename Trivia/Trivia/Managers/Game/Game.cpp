#include "pch.h"
#include "Game.h"

Game::Game(std::vector<Question> questions, std::map<LoggedUser, GameData> players, unsigned int gameId) : m_questions(questions), m_players(players), gameId(gameId)
{
}

Question Game::getQuestionForUser(LoggedUser logUser) 
{
	return m_players.find(logUser)->second.currentQuestion;
}

void Game::submitAnswer(LoggedUser logUser, int answerId)
{
	static int currQuestion = 0;
	currQuestion++;

	if (currQuestion < m_questions.size())
	{
		m_players.find(logUser)->second.currentQuestion = m_questions[currQuestion];
	}

	GameData gd = m_players.find(logUser)->second;
	if (gd.currentQuestion.getCorrectAnswerId() == answerId)
	{
		gd.correctAnswerCount++;
		return;
	}
	gd.wrongAnswerCount++;
}

void Game::removePlayer(LoggedUser logUser)
{
	m_players.erase(logUser);
}


int Game::getGameId()
{
	return gameId;
}

std::map<LoggedUser, GameData> Game::getPlayers()
{
	return m_players;
}
