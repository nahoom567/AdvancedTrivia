#pragma once
#include "Managers/Login/LoggedUser.h"

struct RoomData
{
	// creating a counter so every room will have a differnet id
	std::string name;
	unsigned int id;
	unsigned int maxPlayers;
	unsigned int numOfQuestionsInGame;
	unsigned int timePerQuestion;
	unsigned int isActive;

	RoomData(const std::string& roomName, unsigned int maximumPlayers, unsigned int numOfQuestionsGame, unsigned int timeQuestion, unsigned int ID)
	{
		name = roomName;
		id = ID;
		maxPlayers = maximumPlayers;
		numOfQuestionsInGame = numOfQuestionsGame;
		timePerQuestion = timeQuestion;
		isActive = 1;
	}
};


class Room
{
public:
	Room(const RoomData& rd, const LoggedUser& creatorName);
	void addUser(const LoggedUser& logUser);
	void removeUser(const LoggedUser& logUser);
	std::vector<std::string> getAllUsers();
	RoomData getData() const;
	void setIsActive(int val);

private:
	RoomData m_metadata;
	std::vector<LoggedUser> m_users;
};

