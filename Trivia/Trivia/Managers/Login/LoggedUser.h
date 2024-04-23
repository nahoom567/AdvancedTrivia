#pragma once

class LoggedUser
{
public:
	LoggedUser(const std::string& userName);
	std::string getUsername() const;
	// this has to be done in order to insert LoggedUser to map of LoggedUsers (the map has to use < operator)
	bool operator<(const LoggedUser& other) const
	{
		return m_userName < other.getUsername();
	}
private:
	std::string m_userName;
};

