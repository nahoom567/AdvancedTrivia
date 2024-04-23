#pragma once
#include "DB/SqliteDatabase.h"
#include "LoggedUser.h"

class LoginManager
{
public:
	LoginManager(IDataBase* db);
	bool signup(const std::string& userName, const std::string& password, const std::string& email);
	/// <summary>
	/// get the userName and password and tries to log in in the account 
	/// </summary>
	/// <param name="userName"></param>
	/// <param name="password"></param>
	/// <returns>true - succeeded to login, false - failed to login </returns>
	bool login(const std::string& userName, const std::string& password);
	/// <summary>
	/// tries logout
	/// </summary>
	/// <param name="userName"></param>
	/// <returns>true - succeeded to logout, false - the user is not logged in</returns>
	bool logout(const std::string& userName);
private:
	IDataBase* m_DB;
	std::vector<LoggedUser> m_loggedUsers;
};

