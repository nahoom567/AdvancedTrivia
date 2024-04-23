#include "pch.h"
#include "LoginManager.h"

LoginManager::LoginManager(IDataBase* db) : m_DB(db)
{
    m_DB->open();
}

bool LoginManager::signup(const std::string& userName, const std::string& password, const std::string& email)
{
    int res = m_DB->addNewUser(userName, password, email);
    return (res != -1);
}

bool LoginManager::login(const std::string& userName, const std::string& password)
{
	if (m_DB->doesPasswordMatch(userName, password) != -1)
	{
		m_loggedUsers.push_back(LoggedUser(userName));
		return true;
	}

	return false;
}

bool LoginManager::logout(const std::string& userName)
{
    for (auto iter = m_loggedUsers.begin(); iter != m_loggedUsers.end(); iter++)
    {
        if (iter->getUsername() == userName)
        {
            m_loggedUsers.erase(iter);
            return true;
        }
    }

    return false;
}


