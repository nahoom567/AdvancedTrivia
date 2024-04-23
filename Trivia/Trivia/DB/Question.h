#pragma once
#include "pch.h"

class Question
{
public:
	Question(std::string que, std::vector<std::string> possAns);
	std::string getQuestion() const;
	std::vector<std::string> getPossibleAnswers() const;
	int getCorrectAnswerId();
private:
	std::string m_question;
	std::vector<std::string> m_possibleAnswers;
};

