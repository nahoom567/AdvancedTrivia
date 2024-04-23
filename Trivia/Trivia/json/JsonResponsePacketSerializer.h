#pragma once
#include <iostream>
#include <vector>
#include "json.hpp"
#include "Responses.h"

namespace ResponseCode
{
	enum
	{
		error = 1,
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
		getGameResults = 18,
	};
}

#define CODE_BYTE_NUM 1
#define MSG_SIZE_BYTE_NUM 4


class JsonResponsePacketSerializer
{
public:
	static std::vector<unsigned char> serializeResponse(const ErrorResponse& errResp);
	static std::vector<unsigned char> serializeResponse(const LoginResponse& logResp);
	static std::vector<unsigned char> serializeResponse(const SignupResponse& signRes);
	static std::vector<unsigned char> serializeResponse(const LogoutResponse& response);
	static std::vector<unsigned char> serializeResponse(const GetRoomsResponse& response);
	static std::vector<unsigned char> serializeResponse(const GetPlayersInRoomResponse& response);
	static std::vector<unsigned char> serializeResponse(const JoinRoomResponse& response);
	static std::vector<unsigned char> serializeResponse(const CreateRoomResponse& response);
	static std::vector<unsigned char> serializeResponse(const getHighScoreResponse& response);
	static std::vector<unsigned char> serializeResponse(const getPersonalStatsResponse& response);
	static std::vector<unsigned char> serializeResponse(const CloseRoomResponse& response);
	static std::vector<unsigned char> serializeResponse(const StartGameResponse& response);
	static std::vector<unsigned char> serializeResponse(const GetRoomStateResponse& response);
	static std::vector<unsigned char> serializeResponse(const LeaveRoomResponse& response);
	static std::vector<unsigned char> serializeResponse(const GetGameResultsResponse& response);
	static std::vector<unsigned char> serializeResponse(const SubmitAnswerResponse& response);
	static std::vector<unsigned char> serializeResponse(const GetQuestionResponse& response);
	static std::vector<unsigned char> serializeResponse(const LeaveGameResponse& response);

private:
	static inline std::vector<unsigned char> getBuff(const nlohmann::json& data, const int code);
	static inline std::vector<unsigned char> serializeStatusOnlyResponse(int status, int code);
};
