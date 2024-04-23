#include "pch.h"
#include "helper.h"

char* t_helper::vectToChar(const std::vector<uint8_t>& vec)
{
	char* charArray = new char[vec.size() + 1];

    // Copy data from vector to char array
    for (int i = 0; i < vec.size(); ++i) 
    {
        charArray[i] = static_cast<char>(vec[i]);
    }

    charArray[vec.size()] = '\0';
	return charArray;
}

int t_helper::fourBytetoInt(char integer[])
{
    int value = (integer[0] << 24) | (integer[1] << 16) | (integer[2] << 8) | integer[3];
    return value;
}

void t_helper::intToBytes(int value, unsigned char* bytes)
{
    bytes[0] = (value >> 24) & 0xFF;
    bytes[1] = (value >> 16) & 0xFF;
    bytes[2] = (value >> 8) & 0xFF;
    bytes[3] = value & 0xFF;
}
