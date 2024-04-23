#pragma once
#pragma comment(lib, "ws2_32.lib")
#include "Communicator.h"
#include "server/serverOperation/ServerOperator.h"


class Server
{
public:
	Server();
	~Server();
	void run();
private:
	void handleUserServer();

	bool m_stopServer;
	Communicator m_communicator;
	ServerOperator m_operator;

	std::thread m_userInputThread;
};

