#pragma once
#include <iostream>
#include <vector> 
class IRequestHandler;
class RequestResult
{
public:
	RequestResult(const std::vector<unsigned char>& reponse, IRequestHandler* newHandler) 
		: _response(reponse), _newHandler(newHandler)
	{
	
	};

	std::vector<unsigned char> _response;
	IRequestHandler* _newHandler;
};