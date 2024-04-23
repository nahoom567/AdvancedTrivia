#pragma once
#include "pch.h"
#include "DB/sqlite3.h"
#include "DB/SqliteDatabase.h"

class StatisticsManager
{
public:
	// the record table
	std::vector<std::string> getHighScores() const;
	// personal stats of the user (for now assumed to be score and number of correct answers)
	std::vector<std::string> getUserStatistics(const std::string& username) const;
private:
	SqliteDatabase* m_database;
};

