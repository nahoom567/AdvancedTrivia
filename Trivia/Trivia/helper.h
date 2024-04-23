#pragma once
#include "pch.h"

namespace t_helper
{
	char* vectToChar(const std::vector<uint8_t>& vec);
	int fourBytetoInt(char integer[]);
	void intToBytes(int value, unsigned char* bytes);
}