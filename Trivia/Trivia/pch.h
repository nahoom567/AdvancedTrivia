#pragma once
#include <iostream>
#include <memory>
#include <utility>
#include <algorithm>
#include <functional>
#include <string>
#include <array>
#include <sstream>
#include <vector>
#include <unordered_map>
#include <unordered_set>
#include <sstream>
#include <queue>
#include <bitset>
#include <optional>
#include <set>
#include <fstream>
#include <thread>
#include <mutex>
#include <condition_variable>
#include <WinSock2.h>
#include <Windows.h>
#include <map>
#include <WinSock2.h>
#include <fcntl.h>
#include <filesystem>
void changeColor(const int& color);

#define ERROR_L(x) changeColor(FOREGROUND_RED); std::cerr << "ERROR: " << x << std::endl; changeColor(FOREGROUND_INTENSITY | FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE)
#define PRINT_L(x) std::cout << x << std::endl;
#define PRINT_GRENN_L(x) changeColor(FOREGROUND_GREEN); std::cerr << x << std::endl; changeColor(FOREGROUND_INTENSITY | FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE)

#include "helper.h"