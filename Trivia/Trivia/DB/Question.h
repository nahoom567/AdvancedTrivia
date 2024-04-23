#pragma once
#include "pch.h"

class Question
{
public:
	Question(std::string que, std::vector<std::string> possAns, int ansId);
	std::string getQuestion() const;
	std::vector<std::string> getPossibleAnswers() const;
	int getCorrectAnswerId();
private:
	int ansId;
	std::string m_question;
	std::vector<std::string> m_possibleAnswers;
};

