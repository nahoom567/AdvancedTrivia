#pragma once
#include "DB/IDataBase.h"
#include "DB/SqliteDatabase.h"
#include "Game.h"
#include "Managers/Room/Room.h"


class GameManager
{
public:
	GameManager(IDataBase* db);
	Game& createGame(Room& room);
	void deleteGame(int gameId);
	std::vector<Game>& getGames();

private:
	IDataBase* m_database;
	std::vector<Game> m_games;
	// will be used to give ids for each game
	static int i;
};