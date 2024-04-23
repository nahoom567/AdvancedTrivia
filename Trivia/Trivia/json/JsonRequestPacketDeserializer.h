#pragma once
#include "json.hpp"
#include "Requests.h"

#define SUCCESS_STATUS 1


namespace RequestCode
{
    enum
    {
        login = 2,
        signup = 3,
        logout = 4,
        getRooms = 5,
        getPlayers = 6,
        joinRoom = 7,
        createRoom = 8,
        getHighScore = 9,
        getPersonalScore = 10,
        closeRoom = 11,
        startGame = 12,
        getRoomState = 13,
        leaveRoom = 14,
        leaveGame = 15,
        getQuestions = 16,
        submitAnswers = 17,
        getGameResults = 18
    };
}

class JsonResponsePacketDeserializer
{
public:
	static LoginRequest deserializeLoginRequest(const std::vector<unsigned char>& buffer);
	static SignupRequest deserializeSignupRequest(const std::vector<unsigned char>& buffer);
	static GetPlayersInRoomRequest deserializeGetPlayersRequest(const std::vector<unsigned char>& buffer);
	static JoinRoomRequest deserializeJoinRoomRequest(const std::vector<unsigned char>& buffer);
	static CreateRoomRequest deserializeCreateRoomRequest(const std::vector<unsigned char>& buffer);
    static SubmitAnswerRequest deserializeSubminAnswerRequest(const std::vector<unsigned char>& buffer);
    static int deserializeCreateRoomResponse(const std::vector<unsigned char>& buffer);

private:
    static nlohmann::json getJson(const std::vector<unsigned char>& buffer);
};
