#pragma once
#include "Question.h"

class IDataBase
{
public:
	virtual bool open() = 0;
	virtual bool close() = 0;
	virtual int doesUserExists(const std::string& userName) = 0;
	virtual int doesPasswordMatch(const std::string& userName, const std::string& password) = 0;
	virtual int addNewUser(const std::string& userName, const std::string& password, const std::string& email) = 0;

	virtual std::list<Question> getQuestions(const int&) = 0;
	virtual float getPlayerAverageAnswerTime(const std::string& ) = 0;
	virtual int getNumOfCorrectAnswers(const std::string&) = 0;
	virtual int getNumOfTotalAnswers(const std::string&) = 0;
	virtual int getNumOfPlayerGames(const std::string&) = 0;
	virtual std::vector<std::string> getHighScores() = 0;
	// personal stats of the user (for now assumed to be score and number of correct answers)
	virtual std::vector<std::string> getUserStatistics(const std::string& username) = 0;
};

