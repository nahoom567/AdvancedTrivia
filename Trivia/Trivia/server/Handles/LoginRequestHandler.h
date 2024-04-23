#pragma once
#include "pch.h"
#include "IRequestHandler.h"
#include "server/Infrastructure/RequestHandlerFactory.h"

#define LOGIN_CODE_CHAR '2'
#define SIGNUP_CODE_CHAR '3'
#define SIGNUP_ERROR "an error has occured signing up"
#define LOGIN_ERROR "an error has occured during login process"


class RequestHandlerFactory;

class LoginRequestHandler : public IRequestHandler
{
public:
	LoginRequestHandler(RequestHandlerFactory& handlerFactory);
	~LoginRequestHandler();
	bool isRequestRelevant(const RequestInfo& reqInfo);
	RequestResult handleRequest(const RequestInfo& reqInfo);
	RequestResult login(RequestInfo reqInfo);
	RequestResult signup(RequestInfo reqInfo);
private:
	RequestHandlerFactory& m_handlerFactory;
};

