#include "pch.h"
#include "Server.h"


Server::Server() : m_stopServer(false), m_communicator(m_stopServer)
{
	WSADATA wsa_data = { };
	if (WSAStartup(MAKEWORD(2, 2), &wsa_data) != 0)
		throw std::exception("WSAStartup Failed");
}

Server::~Server()
{
	// Q: why is this try necessary ?
	// A: to avoid throwing exceptions in d-tors !
	// if we do throw think what will happened in regular exception, our object 
	// will be destroyed because an exception occurred and then the d-tor will be 
	// called and if we throw now there is no one to handle the exception because 
	// we are already in the flow of exception handling !! (inception...)
	// please read more about exception handling and why it's forbidden to throw
	// exception from the destructor.
	try
	{
		WSACleanup();
	}
	catch (...) {}
}

void Server::run()
{
	m_userInputThread = std::thread(&Server::handleUserServer, this);
	// m_userInputThread.detach();

	m_communicator.startHandleRequest();
	m_userInputThread.join();
}

void Server::handleUserServer()
{
	m_operator.handleCommand(m_stopServer);
}

