#include "pch.h"
#include "GameManager.h"

int GameManager::i = 0;

GameManager::GameManager(IDataBase* db) : m_database(db)
{
}

Game& GameManager::createGame(Room& room)
{
	// the default amount of questions in a game is 10 for now
	std::list<Question> queList = m_database->getQuestions(10);
	std::vector<Question> queVec;
	std::map<LoggedUser, GameData> mapUsers;
	
	for (const auto& que : queList)
	{
		queVec.push_back(que);
	}
	
	for (auto& user : room.getAllUsers())
	{
		// giving everyone the first question and default values
		GameData gd = GameData(queVec[0], 0, 0, 0.0);
		mapUsers.insert({ LoggedUser(user), gd });
	}
	
	// for game id
	i++;

	Game game = Game(queVec, mapUsers, i - 1);
	m_games.push_back(game);
	return game;
}

void GameManager::deleteGame(int gameId)
{
	for (auto game = m_games.begin(); game != m_games.end(); game++)
	{
		if (game->getGameId() == gameId)
		{
			m_games.erase(game);
		}
	}
}

std::vector<Game>& GameManager::getGames()
{
	return m_games;
}
