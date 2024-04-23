#include "pch.h"
#include "Room.h"

Room::Room(const RoomData& rd, const LoggedUser& creatorName) : m_metadata(rd)
{
	m_users.push_back(creatorName);
}

void Room::addUser(const LoggedUser& logUser)
{
	try
	{
		m_users.push_back(logUser);
	}
	catch (...)
	{
		throw (std::invalid_argument("an error has occured adding logged user to all users"));
	}
}

void Room::removeUser(const LoggedUser& logUser)
{
	for (auto user = m_users.begin(); user != m_users.end(); user++)
	{
		if (user->getUsername() == logUser.getUsername())
		{
			m_users.erase(user);
			return;
		}
	}
}

std::vector<std::string> Room::getAllUsers()
{
	std::vector<std::string> usersList = std::vector<std::string>();
	for (const auto& user : m_users)
	{
		usersList.push_back(user.getUsername());
	}
	return usersList;
}

RoomData Room::getData() const
{
	return m_metadata;
}
