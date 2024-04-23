#pragma once

struct RequestInfo
{
	int id;
	std::time_t recievedTime;
	std::vector<unsigned char> buffer;

	RequestInfo(int reqId, const std::time_t& recTime, const std::vector<unsigned char>& buff)
	{
		id = reqId;
		recievedTime = recTime;
		buffer = buff;
	}
};

class RequestResult;
class IRequestHandler
{
public:
	virtual bool isRequestRelevant(const RequestInfo& reqInfo) = 0;
	virtual RequestResult handleRequest(const RequestInfo& reqInfo) = 0;
private:

};
