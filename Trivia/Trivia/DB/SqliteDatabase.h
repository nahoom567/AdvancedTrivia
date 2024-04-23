#pragma once
#include "sqlite3.h"
#include "IDataBase.h"

#define NUM_QUESTIONS 10
#define NUM_PARAMS 6

class SqliteDatabase : public IDataBase
{
public:
	SqliteDatabase(const std::string& dbName);
	/// <summary>
	/// function opens the database
	/// </summary>
	/// <returns>bool that says if the DB opened successfully</returns>
	bool open() override;
	/// <summary>
	/// function closes the database
	/// </summary>
	/// <returns>bool that says if the DB closed successfully</returns>
	bool close() override;

	/// <summary>
	/// checks if the user exists
	/// </summary>
	/// <param name="userName"></param>
	/// <returns>the id of the userName if it exists and if there is no user found returns -1</returns>
	int doesUserExists(const std::string& userName) override;
	/// <summary>
	/// checks if the password is the users password
	/// </summary>
	/// <param name="userName"></param>
	/// <param name="password"></param>
	/// <returns>the id of the user if the password is matching the name of the user or in the case of an error that the user does not exists or its not is password returns -1</returns>
	int doesPasswordMatch(const std::string& userName, const std::string& password) override;
	/// <summary>
	/// adding a new user
	/// </summary>
	/// <param name="userName"></param>
	/// <param name="password"></param>
	/// <param name="email"></param>
	/// <returns>the id of the user</returns>
	int addNewUser(const std::string& userName, const std::string& password, const std::string& email) override;

	void createQuestionsTable(); 

	bool createQuestion(const std::string& que, const std::string& firAns, const std::string& secAns, const std::string& thAns, const std::string& fourAns, const int& rightAns);

	void createStatsTable(); 

	std::list<Question> getQuestions(const int& numQuestions) override;

	float getPlayerAverageAnswerTime(const std::string& userName) override;

	int getNumOfCorrectAnswers(const std::string& userName) override; 

	int getNumOfTotalAnswers(const std::string& userName) override;

	int getNumOfPlayerGames(const std::string& userName) override; 

	// the record table
	std::vector<std::string> getHighScores() override;
	// personal stats of the user (for now assumed to be score and number of correct answers)
	std::vector<std::string> getUserStatistics(const std::string& username) override;

	

private:
	void addTables();
	void deleteDataBase();
	inline bool sentRequest(const std::string& request, void* dataStructure = nullptr, int (*callback)(void*, int, char**, char**) = nullptr);

	sqlite3* m_DB;
	std::string m_DBName;
};

