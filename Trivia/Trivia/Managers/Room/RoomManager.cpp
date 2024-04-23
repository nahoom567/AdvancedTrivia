#include "pch.h"
#include "RoomManager.h"


RoomManager::RoomManager()
{

}

RoomManager::~RoomManager()
{
}

bool RoomManager::createRoom(const LoggedUser& logUser, const RoomData& rd)
{
	return (m_rooms.insert(std::make_pair(rd.id, Room(rd, logUser)))).second;
}

void RoomManager::deleteRoom(int ID)
{
	for (auto room = m_rooms.begin(); room != m_rooms.end(); room++)
	{
		if (room->first == ID)
		{
			m_rooms.erase(room);
			return;
		}
	}
}

unsigned int RoomManager::getRoomState(int ID) const
{
	for(const auto& room : m_rooms)
	{
		if ((int)(room.first) == ID)
		{
			int i = room.second.getData().isActive;
			return i;
		}
	}
	return 0;
}

std::vector<RoomData> RoomManager::getRooms() const
{
	std::vector<RoomData> roomsList = std::vector<RoomData>();
	for (const auto& room : m_rooms)
	{
		roomsList.push_back(room.second.getData());
	}
	return roomsList;
}

Room& RoomManager::getRoom(int ID)
{
	for (auto& room : m_rooms)
	{
		if (room.first == ID)
		{
			return room.second;
		}
	}
	throw std::exception("there was a problem getting room");
}
