#include "pch.h"
#include "JsonResponsePacketSerializer.h"
#include "json.hpp"

#define SIZE_LENGTH_MSG 4

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(const ErrorResponse& errResp)
{
	// converting json to bytes 
	nlohmann::json data =
	{
	  {R"(status)", errResp.message}
	};
	return getBuff(data, ResponseCode::error);
}

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(const LoginResponse& logResp)
{
	return serializeStatusOnlyResponse(logResp.status, ResponseCode::login);
}

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(const SignupResponse& signRes)
{
	return serializeStatusOnlyResponse(signRes.status, ResponseCode::signup);
}

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(const LogoutResponse& response)
{
	return serializeStatusOnlyResponse(response.status, ResponseCode::logout);
}

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(const GetRoomsResponse& response)
{
	// converting json to bytes 
	nlohmann::json data = {
		{R"(status)", response.status}
	};
	for (auto& room : response.rooms)
	{
		nlohmann::json temp = {
			{R"(name)", room.name},
			{R"(roomId)", room.id},
			{R"(maxPlayers)", room.maxPlayers},
			{R"(numOfQuestionsInGame)", room.numOfQuestionsInGame},
			{R"(timePerQuestion)", room.timePerQuestion},
			{R"(isActive)", room.isActive},
		};

		data["rooms"].emplace_back(temp);
	}

	return getBuff(data, ResponseCode::getRooms);
}

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(const GetPlayersInRoomResponse& response)
{
	// converting json to bytes 
	nlohmann::json data;

	for (auto& player : response.players)
	{
		data["players"].emplace_back(player);
	}

	return getBuff(data, ResponseCode::getPlayers);
}

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(const JoinRoomResponse& response)
{
	return serializeStatusOnlyResponse(response.status, ResponseCode::joinRoom);
}

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(const CreateRoomResponse& response)
{
	return serializeStatusOnlyResponse(response.status, ResponseCode::createRoom);
}

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(const getHighScoreResponse& response)
{
	// converting json to bytes 
	nlohmann::json data = {
		{R"(status)", response.status}
	};

	for (auto& statistic : response.statistics)
	{
		data["statistics"].emplace_back(statistic);
	}

	return getBuff(data, ResponseCode::getHighScore);
}

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(const getPersonalStatsResponse& response)
{
	// converting json to bytes 
	nlohmann::json data = {
		{R"(status)", response.status}
	};

	for (auto& statistic : response.statistics)
	{
		data["personalStats"].emplace_back(statistic);
	}

	return getBuff(data, ResponseCode::getHighScore);
}

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(const CloseRoomResponse& response)
{
	return serializeStatusOnlyResponse(response.status, ResponseCode::closeRoom);
}

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(const StartGameResponse& response)
{
	return serializeStatusOnlyResponse(response.status, ResponseCode::startGame);
}

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(const GetRoomStateResponse& response)
{
	// converting json to bytes 
	nlohmann::json data = {
	  {R"(status)", response.status},
	  {R"(hasGameBegun)", response.hasGameBegun},
	  {R"(players)", response.players},
	  {R"(AnswerCount)", response.questionCount},
	  {R"(answerTimeOut)", response.answerTimeout},
	};
	return getBuff(data, ResponseCode::getRoomState);
}

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(const LeaveRoomResponse& response)
{
	return serializeStatusOnlyResponse(response.status, ResponseCode::leaveRoom);
}

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(const GetGameResultsResponse& response)
{
	nlohmann::json data = {
		{R"(status)", response.status}
	};

	for (auto& result : response.results)
	{
		nlohmann::json temp = {
			{R"(averageAnswerTime)", result.averageAnswerTime},
			{R"(correctAnswerCount)", result.correctAnswerCount},
			{R"(username)", result.username},
			{R"(wrongAnswerCount)", result.wrongAnswerCount},
		};
		data["results"].emplace_back(temp);
	}
	
	return getBuff(data, ResponseCode::getGameResults);
}

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(const SubmitAnswerResponse& response)
{
	nlohmann::json data = {
		{R"(status)", response.status},
		{R"(correctAnswerId)", response.correctAnswerId}
	};

	return getBuff(data, ResponseCode::submitAnswers);
}

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(const GetQuestionResponse& response)
{
	nlohmann::json data = {
		{R"(status)", response.status},
		{R"(question)", response.question}
	};

	data["map_answer"] = response.answers;

	return getBuff(data, ResponseCode::getQuestions);
}

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(const LeaveGameResponse& response)
{
	return serializeStatusOnlyResponse(response.status, ResponseCode::leaveGame);
}

std::vector<unsigned char> JsonResponsePacketSerializer::getBuff(const nlohmann::json& data, int code)
{
	std::string msg = data.dump();
	std::vector<unsigned char> dataMsg(msg.begin(), msg.end());

	// calculating the number of bytes
	unsigned char size[4];
	t_helper::intToBytes(dataMsg.size(), size);

	std::vector<unsigned char> buffer;
	buffer.reserve(dataMsg.size() + CODE_BYTE_NUM + MSG_SIZE_BYTE_NUM); // allocating space in the vector so we wont have to recreate it each time 
	buffer.push_back((unsigned char)(code)); // adding the the msg code to the start of the vector

	// adding the padding zero because the length should be 4 bytes:s
	buffer.insert(buffer.end(), size, size + 4);

	buffer.insert(buffer.end(), dataMsg.begin(), dataMsg.end());

	const char* charArray = reinterpret_cast<const char*>(buffer.data());
	return buffer;
}

inline std::vector<unsigned char> JsonResponsePacketSerializer::serializeStatusOnlyResponse(int status, int code)
{
	// converting json to bytes 
	nlohmann::json data = {
	  {R"(status)", status}
	};
	return getBuff(data, code);
}
