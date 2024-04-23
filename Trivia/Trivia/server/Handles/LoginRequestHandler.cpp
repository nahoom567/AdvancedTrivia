#include "pch.h"
#include "LoginRequestHandler.h"
#include "json/JsonResponsePacketSerializer.h"
#include "RequestResult.h"
#include "Managers/Login/LoginManager.h"
#include "json/JsonRequestPacketDeserializer.h"
#include "MenuRequestHandler.h"

LoginRequestHandler::LoginRequestHandler(RequestHandlerFactory& handlerFactory) : m_handlerFactory(handlerFactory)
{

}

LoginRequestHandler::~LoginRequestHandler()
{
	// delete this;
}

bool LoginRequestHandler::isRequestRelevant(const RequestInfo& reqInfo)
{
	return (reqInfo.id == RequestCode::signup || reqInfo.id == RequestCode::login);
}

RequestResult LoginRequestHandler::handleRequest(const RequestInfo& reqInfo)
{
	if (reqInfo.id == ResponseCode::login)
	{
		return this->login(reqInfo);
	}

	return this->signup(reqInfo);
}

RequestResult LoginRequestHandler::login(RequestInfo reqInfo)
{
	LoginRequest logRequest = JsonResponsePacketDeserializer::deserializeLoginRequest(reqInfo.buffer);
	LoginManager& logManager = m_handlerFactory.getLoginManager();
	bool resp = logManager.login(logRequest.username, logRequest.password);

	if (resp)
	{
		return RequestResult(JsonResponsePacketSerializer::serializeResponse(LoginResponse(resp)), 
			m_handlerFactory.createMenuRequestFactory(LoggedUser(logRequest.username)));
	}
	
	// incase of an error:
	std::vector<unsigned char> response = JsonResponsePacketSerializer::serializeResponse(ErrorResponse(LOGIN_ERROR));
	return RequestResult(response, this);
	
	
}

RequestResult LoginRequestHandler::signup(RequestInfo reqInfo)
{
	SignupRequest signRequest = JsonResponsePacketDeserializer::deserializeSignupRequest(reqInfo.buffer);
	LoginManager& logManager = m_handlerFactory.getLoginManager();
	bool resp = logManager.signup(signRequest.username, signRequest.password, signRequest.email);

	if (resp)
	{
		// delete this;
		return RequestResult(JsonResponsePacketSerializer::serializeResponse(SignupResponse(resp)), m_handlerFactory.createMenuRequestFactory(LoggedUser(signRequest.username)));
	}

	// incase of an error:
	std::vector<unsigned char> response = JsonResponsePacketSerializer::serializeResponse(ErrorResponse(SIGNUP_ERROR));
	return RequestResult(response, this);
	
}
