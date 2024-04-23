#include "pch.h"
#include "ServerOperator.h"

int ServerOperator::handleCommand(bool& stopServer) const
{
    std::string input = "";
    
    
    while (!stopServer)
    {
        std::cin >> input;
        if (input == "EXIT") {
            stopServer = true;
            return -1;
        }
        else {
            std::cout << "Invalid input\n";
        }
    }

    return -1;
}
