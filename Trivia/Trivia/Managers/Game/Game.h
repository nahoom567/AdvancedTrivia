#pragma once
#include "Managers/Login/LoggedUser.h"
#include "DB/Question.h"

struct GameData
{
	Question currentQuestion;
	unsigned int correctAnswerCount;
	unsigned int wrongAnswerCount;
	float averangeAnswerTime;
};

class Game
{
public:
	Game(std::vector<Question> questions, std::map<LoggedUser, GameData> players, unsigned int gameId);
	~Game()
	{

	}
	Question getQuestionForUser(LoggedUser logUser);
	void submitAnswer(LoggedUser logUser, int answerId);
	void removePlayer(LoggedUser logUser);
	int getGameId();
	std::map<LoggedUser, GameData> getPlayers();


private:
	std::vector<Question> m_questions;
	std::map<LoggedUser, GameData> m_players;
	unsigned int gameId;
};

