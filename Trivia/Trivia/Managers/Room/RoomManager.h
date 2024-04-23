#pragma once
#include "Managers/Room/Room.h"

class RoomManager
{
public:
	RoomManager();
	~RoomManager();
	bool createRoom(const LoggedUser& logUser, const RoomData& rd);
	void deleteRoom(int ID);
	unsigned int getRoomState(int ID) const;
	std::vector<RoomData> getRooms() const;
	Room& getRoom(int ID);
private:
	std::map<int, Room> m_rooms;
};

