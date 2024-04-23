#pragma once

class LoggedUser
{
public:
	LoggedUser(const std::string& userName);
	std::string getUsername() const;
private:
	std::string m_userName;
};

