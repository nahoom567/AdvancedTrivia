#include "pch.h"
#include "RoomAdminRequestHandler.h"
#include "json/JsonRequestPacketDeserializer.h"
#include "json/JsonResponsePacketSerializer.h"
#include "RequestResult.h"
#include "GameRequestHandler.h"

RoomAdminRequestHandler::RoomAdminRequestHandler(unsigned int roomId, const LoggedUser& logUser, RoomManager& roomManager,
	RequestHandlerFactory& handlerFact) : m_room(handlerFact.getRoomManager().getRoom(roomId)), 
		m_user(logUser), m_roomManager(roomManager), m_handlerFactory(handlerFact), m_roomId(roomId)
{

}

bool RoomAdminRequestHandler::isRequestRelevant(const RequestInfo& reqInfo)
{
	return reqInfo.id == RequestCode::closeRoom || reqInfo.id == RequestCode::startGame || reqInfo.id == RequestCode::getRoomState;
}

RequestResult RoomAdminRequestHandler::handleRequest(const RequestInfo& reqInfo)
{
	switch(reqInfo.id)
	{
	case RequestCode::startGame:
		return this->startGame(reqInfo);
	case RequestCode::closeRoom:
		return this->closeRoom();
	case RequestCode::getRoomState:
		return this->getRoomState();
	}
}

RequestResult RoomAdminRequestHandler::closeRoom()
{
	m_handlerFactory.getRoomManager().deleteRoom(m_room.getData().id);
	IRequestHandler* reqHandler = m_handlerFactory.createMenuRequestFactory(m_user);
	
	return RequestResult(JsonResponsePacketSerializer::serializeResponse(LeaveRoomResponse(1)), reqHandler);

}

RequestResult RoomAdminRequestHandler::startGame(const RequestInfo& reqInfo)
{
	m_handlerFactory.getRoomManager().getRoom(m_roomId).setIsActive(ROOM_GAME_STARTED);
	m_handlerFactory.getGameManager().createGame(m_room);
	GameRequestHandler* reqHandler = m_handlerFactory.createGameRequestHandler(m_user);
	return RequestResult(JsonResponsePacketSerializer::serializeResponse(StartGameResponse(1)), reqHandler);
}


RequestResult RoomAdminRequestHandler::getRoomState()
{
	if (!m_roomManager.getRoomState(m_roomId))
	{
		return RequestResult(JsonResponsePacketSerializer::serializeResponse(GetRoomStateResponse(0, 0,
			std::vector<std::string>(), 0, 0)), m_handlerFactory.createMenuRequestFactory(m_user));
	}
	else if (m_room.getData().isActive == ROOM_WAITING_STATE)
	{
		RoomData rd = m_room.getData();
		return RequestResult(JsonResponsePacketSerializer::serializeResponse(GetRoomStateResponse(m_roomManager.getRoomState(rd.id), 0,
			m_room.getAllUsers(), rd.numOfQuestionsInGame, rd.timePerQuestion)), this);
	}
	else if (m_room.getData().isActive == ROOM_GAME_STARTED)
	{
		RoomData rd = m_room.getData();
		return RequestResult(JsonResponsePacketSerializer::serializeResponse(GetRoomStateResponse(1, true,
			m_room.getAllUsers(), rd.numOfQuestionsInGame, rd.timePerQuestion)), m_handlerFactory.createGameRequestHandler(m_user));
	}
}

