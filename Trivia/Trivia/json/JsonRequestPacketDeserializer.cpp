#include "pch.h"
#include "JsonRequestPacketDeserializer.h"

LoginRequest JsonResponsePacketDeserializer::deserializeLoginRequest(const std::vector<unsigned char>& buffer)
{
	nlohmann::json data = getJson(buffer);
	std::string username = data["username"];
	std::string password = data["password"];
	return LoginRequest(username, password);
}

SignupRequest JsonResponsePacketDeserializer::deserializeSignupRequest(const std::vector<unsigned char>& buffer)
{
	nlohmann::json data = getJson(buffer);
	std::string username = data["username"];
	std::string password = data["password"];
	std::string email = data["mail"];
	return SignupRequest(username, password, email);
}

GetPlayersInRoomRequest JsonResponsePacketDeserializer::deserializeGetPlayersRequest(const std::vector<unsigned char>& buffer)
{
	nlohmann::json data = getJson(buffer);
	return GetPlayersInRoomRequest(data["roomId"]);
}

JoinRoomRequest JsonResponsePacketDeserializer::deserializeJoinRoomRequest(const std::vector<unsigned char>& buffer)
{
	nlohmann::json data = getJson(buffer);
	return JoinRoomRequest(data["roomId"]);
}

CreateRoomRequest JsonResponsePacketDeserializer::deserializeCreateRoomRequest(const std::vector<unsigned char>& buffer)
{
	nlohmann::json data = getJson(buffer);
	std::string roomName = data["roomName"];
	int unsigned maxUsers = data["maxUsers"];
	int unsigned questionCount = data["questionCount"];
	int unsigned answerTimeout = data["answerTimeout"];
	return CreateRoomRequest(roomName, maxUsers, questionCount, answerTimeout);
}

SubmitAnswerRequest JsonResponsePacketDeserializer::deserializeSubminAnswerRequest(const std::vector<unsigned char>& buffer)
{
	nlohmann::json data = getJson(buffer);
	return SubmitAnswerRequest(data["answerId"]);
}

int JsonResponsePacketDeserializer::deserializeCreateRoomResponse(const std::vector<unsigned char>& buffer)
{
	nlohmann::json data = getJson(buffer);
	return data["status"]; // getting the roomId of out of the buffer
}

nlohmann::json JsonResponsePacketDeserializer::getJson(const std::vector<unsigned char>& buffer)
{
	// getting the index of the first '{' which symbalizes the start of the json
	int index = 0;
	auto it = std::find(buffer.begin(), buffer.end(), '{');
	if (it != buffer.end()) {
		index = std::distance(buffer.begin(), it);
	}
	else {
		ERROR_L("there was an error with the buffer that has been sent");
		throw std::exception("there was an error with the buffer that has been sent");
	}

	// this is the buffer with the information of the json
	std::string jsonData(buffer.begin() + index, buffer.end());

	// parsing the JSON string to extract the attributes
	nlohmann::json data = nlohmann::json::parse(jsonData);
	return data;
}
