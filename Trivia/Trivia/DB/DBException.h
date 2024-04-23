#pragma once
#include "pch.h"

class DBException : std::exception
{
public:
	DBException(const std::string error) : m_error(error) {}
	virtual ~DBException() noexcept = default;
	virtual const char* what() const noexcept { return m_error.c_str(); }

private:
	std::string m_error;
};

