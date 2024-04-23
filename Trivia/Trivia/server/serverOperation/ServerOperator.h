#pragma once

enum commandType
{
	EXIT,
};

class ServerOperator
{
public:
	ServerOperator()
	{
		
	}
	~ServerOperator()
	{

	}
	
	int handleCommand(bool& stopServer) const;
private:
};

