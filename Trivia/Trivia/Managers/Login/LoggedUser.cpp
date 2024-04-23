#include "pch.h"
#include "LoggedUser.h"

LoggedUser::LoggedUser(const std::string& userName)
{
    m_userName = userName;
}

std::string LoggedUser::getUsername() const 
{
    return m_userName;
}
