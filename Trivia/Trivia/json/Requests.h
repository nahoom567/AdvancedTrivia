#pragma once
#include "pch.h"

struct LoginRequest
{
    std::string username;
    std::string password;
    LoginRequest(const std::string& user, const std::string& pass)
    {
        username = user;
        password = pass;
    }
};

struct SignupRequest
{
    std::string username;
    std::string password;
    std::string email;
    SignupRequest(const std::string& user, const std::string& pass, const std::string& mail)
    {
        username = user;
        password = pass;
        email = mail;
    }
};

struct GetPlayersInRoomRequest
{
    unsigned int roomId;
};


struct JoinRoomRequest
{
    unsigned int roomId;
};

struct CreateRoomRequest
{
    std::string roomName;
    unsigned int maxUsers;
    unsigned int questionCount;
    unsigned int answerTimeout;
};

struct SubmitAnswerRequest
{
    unsigned int answerId;
};
