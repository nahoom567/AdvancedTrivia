#include "pch.h"
#include "StatisticsManager.h"

std::vector<std::string> StatisticsManager::getHighScores() const
{
	return m_database->getHighScores();
}

std::vector<std::string> StatisticsManager::getUserStatistics(const std::string& username) const
{
	return m_database->getUserStatistics(username);
}

