#include "pch.h"
#include "Question.h"

Question::Question(std::string que, std::vector<std::string> possAns) : m_question(que), m_possibleAnswers(possAns)
{

}

std::string Question::getQuestion() const
{
    return m_question;
}

std::vector<std::string> Question::getPossibleAnswers() const
{
    return m_possibleAnswers;
}

int Question::getCorrectAnswerId()
{
    // understand what is it
    return 0;
}
