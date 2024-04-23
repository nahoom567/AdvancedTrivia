#pragma once
#include "pch.h"
#include "Managers/Room/RoomManager.h"

struct LoginResponse
{
    unsigned int status;
};

struct SignupResponse
{
    unsigned int status;
};

struct ErrorResponse
{
    std::string message;
};

struct LogoutResponse
{
    unsigned int status;
};

struct GetRoomsResponse
{
    unsigned int status;
    std::vector<RoomData> rooms;
};

struct GetPlayersInRoomResponse
{
    std::vector<std::string> players;
};

struct getHighScoreResponse
{
    unsigned int status;
    std::vector<std::string> statistics;
};

struct getPersonalStatsResponse
{
    unsigned int status;
    std::vector<std::string> statistics;
};

struct JoinRoomResponse
{
    unsigned int status;
};

struct CreateRoomResponse
{
    unsigned int status;
};

struct CloseRoomResponse
{
    unsigned int status;
};

struct StartGameResponse
{
    unsigned int status;
};

struct GetRoomStateResponse
{
    unsigned int status;
    bool hasGameBegun;
    std::vector<std::string> players;
    unsigned int questionCount;
    unsigned int answerTimeout;
};

struct LeaveRoomResponse
{
    unsigned int status;
};

struct LeaveGameResponse
{
    unsigned int status;
};

struct GetQuestionResponse
{
    unsigned int status;
    std::string question;
    std::map<unsigned int, std::string> answers;
};

struct SubmitAnswerResponse
{
    unsigned int status;
    unsigned int correctAnswerId;
};

struct PlayerResults
{
    std::string username;
    unsigned int correctAnswerCount;
    unsigned int wrongAnswerCount;
    unsigned int averageAnswerTime;
};

struct GetGameResultsResponse
{
    int status;
    std::vector<PlayerResults> results;
};
