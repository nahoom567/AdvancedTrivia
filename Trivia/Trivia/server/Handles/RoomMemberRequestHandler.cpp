#include "pch.h"
#include "RoomMemberRequestHandler.h"
#include "RequestResult.h"

RoomMemberRequestHandler::RoomMemberRequestHandler(unsigned int roomId, const LoggedUser& logUser, RoomManager& roomManager,
		RequestHandlerFactory& handlerFact) : m_room(handlerFact.getRoomManager().getRoom(roomId)), 
	m_user(logUser), m_roomManager(roomManager), m_handlerFactory(handlerFact), m_roomId(roomId)
{
}

bool RoomMemberRequestHandler::isRequestRelevant(const RequestInfo& reqInfo)
{
	return reqInfo.id == RequestCode::leaveRoom || reqInfo.id == RequestCode::getRoomState || reqInfo.id == RequestCode::closeRoom;
}

RequestResult RoomMemberRequestHandler::handleRequest(const RequestInfo& reqInfo)
{
	switch (reqInfo.id)
	{
	case RequestCode::leaveRoom:
		return this->leaveRoom();
	case RequestCode::getRoomState:
		return this->getRoomState();
	case ResponseCode::closeRoom:
		return this->roomGotClosed(reqInfo.buffer);
	}
}

RequestResult RoomMemberRequestHandler::leaveRoom()
{
	m_room.removeUser(m_user);
	IRequestHandler* reqHandler = m_handlerFactory.createMenuRequestFactory(m_user);
	return RequestResult(JsonResponsePacketSerializer::serializeResponse(LeaveRoomResponse(1)), reqHandler);
}

RequestResult RoomMemberRequestHandler::getRoomState()
{
	if (!m_roomManager.getRoomState(m_roomId))
	{
		return RequestResult(JsonResponsePacketSerializer::serializeResponse(GetRoomStateResponse(0, 0,
			std::vector<std::string>(), 0, 0)), m_handlerFactory.createMenuRequestFactory(m_user));
	}
	else
	{
		RoomData rd = m_room.getData();
		return RequestResult(JsonResponsePacketSerializer::serializeResponse(GetRoomStateResponse(m_roomManager.getRoomState(rd.id), rd.isActive,
			m_room.getAllUsers(), rd.numOfQuestionsInGame, rd.timePerQuestion)), this);
	}
}

RequestResult RoomMemberRequestHandler::roomGotClosed(const std::vector<uint8_t>& buffer)
{
	if (m_room.getData().id == (int)buffer[0])
	{
		return leaveRoom();
	}

	return RequestResult(JsonResponsePacketSerializer::serializeResponse(ErrorResponse("this user is not in the requested room")), this);
}