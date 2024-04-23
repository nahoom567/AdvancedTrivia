#include "pch.h"
#include "RequestHandlerFactory.h"

RequestHandlerFactory::RequestHandlerFactory(IDataBase* database) : m_database(database), 
m_loginManager(*(new LoginManager(database))), m_statsManager(*(new StatisticsManager())), m_roomManager(*(new RoomManager()))
{
}

RequestHandlerFactory::~RequestHandlerFactory()
{
    m_database->close();
    delete m_database;
    delete &m_loginManager;
    delete &m_statsManager;
    delete &m_roomManager;
}

LoginRequestHandler* RequestHandlerFactory::createLoginRequestHandler()
{
    return new LoginRequestHandler(*this);
}

LoginManager& RequestHandlerFactory::getLoginManager()
{
    return m_loginManager;
}

MenuRequestHandler* RequestHandlerFactory::createMenuRequestFactory(const LoggedUser& logUser)
{
    return new MenuRequestHandler(logUser, *this);
}


StatisticsManager& RequestHandlerFactory::getStatisticsManager()
{
    return m_statsManager;
}

RoomManager& RequestHandlerFactory::getRoomManager()
{
    return m_roomManager;
}


RoomAdminRequestHandler* RequestHandlerFactory::createRoomAdminRequestHandler(const LoggedUser& logUser, const Room& room)
{
    return new RoomAdminRequestHandler(room.getData().id, logUser, m_roomManager, *this);
}

RoomMemberRequestHandler* RequestHandlerFactory::createRoomMemberRequestHandler(const LoggedUser& logUser, const Room& room)
{
     return new RoomMemberRequestHandler(room.getData().id, logUser, m_roomManager, *this);
}