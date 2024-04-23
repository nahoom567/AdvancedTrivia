#include "pch.h"
#include "SqliteDatabase.h"
#include "DBException.h"


SqliteDatabase::SqliteDatabase(const std::string& dbName) : m_DBName(dbName)
{

}

bool SqliteDatabase::open()
{
	bool DBExists = std::filesystem::exists(m_DBName);

	int res = sqlite3_open(m_DBName.c_str(), &m_DB);
	if (res != SQLITE_OK)
	{
		m_DB = nullptr;
		DBException("Error: failed to open DB");

		return false;
	}

	if (!DBExists)
	{
		addTables();
		createQuestionsTable();
		createStatsTable();
	}

	return true;
}

bool SqliteDatabase::close()
{
	int res = sqlite3_close(m_DB);
	if (res != SQLITE_OK)
	{
		m_DB = nullptr;
		DBException("Error: failed to close DB");

		return false;
	}

	m_DB = nullptr;
	return true;
}

int SqliteDatabase::doesUserExists(const std::string& userName)
{
	int id = -1;
	std::string query = "SELECT id FROM USERS WHERE userName = '?';";
	size_t pos = query.find("?");
	query.replace(pos, 1, userName);

	auto callback = [](void* data, int argc, char** argv, char** azColName) -> int {
		int* id = static_cast<int*>(data);
		*id = std::stoi(argv[0]);
		return 0;
	};

	sentRequest(query, &id, callback);

	return id;
}

int SqliteDatabase::doesPasswordMatch(const std::string& userName, const std::string& password)
{
	std::string query = "SELECT id, password FROM users WHERE userName = '?';";
	std::pair<int, std::string> pair = std::pair<int, std::string>(-1, ""); // the id and password of the user
	size_t pos = query.find("?");
	query.replace(pos, 1, userName);

	auto callback = [](void* data, int argc, char** argv, char** azColName) -> int {
		std::pair<int, std::string>* pair = static_cast<std::pair<int, std::string>*>(data);
		pair->first = std::stoi(argv[0]);
		pair->second = std::string(argv[1]);
		return 0;
	};

	sentRequest(query, &pair, callback);
	if (pair.second == password)
	{
		return pair.first;
	}

	return -1;
}

int SqliteDatabase::addNewUser(const std::string& userName, const std::string& password, const std::string& email)
{
	std::string request = "INSERT INTO USERS (userName, email, password) VALUES ('?', '?', '?');";
	bool succeeded = false;

	// replacing the userName
	size_t pos = request.find("?");
	request.replace(pos, 1, userName);
	
	// replacing the password
	pos = request.find("?");
	request.replace(pos, 1, email);

	// replacing the email
	pos = request.find("?");
	request.replace(pos, 1, password);

	succeeded = sentRequest(request);
	if (succeeded)
	{
		return doesUserExists(userName);
	}

	return -1;
}

inline bool SqliteDatabase::sentRequest(const std::string& request, void* dataStructure, int(*callback)(void*, int, char**, char**))
{
	char* errMsg = nullptr;
	int res = sqlite3_exec(m_DB, request.c_str(), callback, dataStructure, &errMsg);
	if (res != SQLITE_OK)
	{
		DBException(*errMsg);
		return false;
	}

	return true;
}

void SqliteDatabase::createQuestionsTable()
{
	bool succ = sentRequest(R"(
    CREATE TABLE QUESTIONS (
        id INTEGER PRIMARY KEY,
        Question TEXT NOT NULL,
        firstAnswer TEXT NOT NULL,
        secondAnswer TEXT NOT NULL,
		thirdAnswer TEXT NOT NULL,
		fourthAnswer TEXT NOT NULL,
		rightAnswer INTEGER NOT NULL
    ); )");

	if (succ == false)
	{
		std::cout << "an error has occured creating table of questions" << std::endl;
	}

	std::string questions[][NUM_PARAMS] = {
	{
		"What did the computer do at the party?",
		"It went for a byte.",
		"It started a recursion dance.",
		"It made everyone laugh with its clever jokes.",
		"It crashed after too many social interactions.",
		"1"
	},
	{
		"Why did the programmer bring a ladder to the office?",
		"To reach the top shelf.",
		"To fix the network cables on the ceiling.",
		"To debug higher-level code.",
		"To climb the corporate ladder.",
		"4"
	},
	{
		"How many programmers does it take to change a light bulb?",
		"None, thats a hardware issue.",
		"One, but they need to consult Stack Overflow first.",
		"Two, one to change it and one to document the process.",
		"It depends, are they using Agile methodology?",
		"1"
	},
	{
		"Why did the developer go broke?",
		"They spent all their money on software licenses.",
		"They invested in a startup that crashed.",
		"They couldnt find their Java inheritance.",
		"They used up all their cache.",
		"3"
	},
	{
		"How do you debug a broken website?",
		"With a browser extension that fixes everything.",
		"By blaming the CSS files.",
		"By asking the user to clear their browser cache.",
		"By throwing the computer out the window.",
		"3"
	},
	{
		"Whats a programmers favorite type of bean?",
		"Garbanzo beans",
		"Boolean beans",
		"Coffee beans",
		"Jelly beans",
		"2"
	},
	{
		"How do programmers like their coffee?",
		"As dark as their screen background.",
		"With a Java bean on top.",
		"Decaffeinated to minimize bugs.",
		"With a for loop stirring motion.",
		"2"
	},
	{
		"Why did the programmer go to the gym?",
		"To exercise their git muscles.",
		"To work on their core processing power.",
		"To do some intensive coding reps.",
		"To challenge the weights to a code competition.",
		"1"
	},
	{
		"What do you call a coding dog?",
		"A pointer retriever.",
		"A codehound.",
		"A binary beagle.",
		"A compiler collie.",
		"4"
	},
	{
		"How does a programmer propose to their partner?",
		"With a ring made of recycled keyboard keys.",
		"By saying You complete my code.",
		"By writing a function that returns I love you.",
		"With a romantic dinner in a server room.",
		"3"
	}
	};

	for (int i = 0; i < NUM_QUESTIONS; i++)
	{
		if (createQuestion(questions[i][0], questions[i][1], questions[i][2], questions[i][3], questions[i][4], stoi(questions[i][5])) == false)
		{
			std::cout << "an error has occured creating user number " + std::to_string(i) << std::endl;
		}
	}
}

bool SqliteDatabase::createQuestion(const std::string& que, const std::string& firAns, const std::string& secAns, const std::string& thAns, const std::string& fourAns, const int& rightAns)
{
	std::string request = "INSERT INTO QUESTIONS (Question, firstAnswer, secondAnswer, thirdAnswer, fourthAnswer, rightAnswer) VALUES ('@', '@', '@', '@', '@', '@');";
	bool succeeded = false;

	// replacing the question
	size_t pos = request.find("@");
	request.replace(pos, 1, que);

	// replacing the first answer
	pos = request.find("@");
	request.replace(pos, 1, firAns);

	// replacing the second answer
	pos = request.find("@");
	request.replace(pos, 1, secAns);

	// replacing the third answer
	pos = request.find("@");
	request.replace(pos, 1, thAns);

	// replacing the fourth answer
	pos = request.find("@");
	request.replace(pos, 1, fourAns);

	// replacing the right answer
	pos = request.find("@");
	request.replace(pos, 1, std::to_string(rightAns));

	succeeded = sentRequest(request);
	return succeeded;
}

void SqliteDatabase::createStatsTable()
{
	// table of statistics for a game
	bool succ = sentRequest(R"(
    CREATE TABLE STATISTICS (
        gameId INTEGER PRIMARY KEY,
        winner TEXT NULL,
        isActive BOOLEAN NOT NULL
    ); )");

	if (succ == false)
	{
		std::cout << "an error has occured creating table of questions" << std::endl;
	}

	// table of statistics for an individual
	succ = sentRequest(R"(
    CREATE TABLE PLAYER (
        gameId INTEGER PRIMARY KEY,
        playerId INTEGER NOT NULL,
		playerName TEXT NOT NULL,
		numGames INTEGER NULL DEFAULT 0,
        avgTime INTEGER NULL DEFAULT 0,
        numQueAnswered INTEGER NOT NULL DEFAULT 0,
		numCorrectAns INTEGER NOT NULL DEFAULT 0,
		score INTEGER NOT NULL DEFAULT 0
    ); )");

	if (succ == false)
	{
		std::cout << "an error has occured creating table of questions" << std::endl;
	}
}

std::list<Question> SqliteDatabase::getQuestions(const int& numQuestions)
{
	std::string query = "SELECT * FROM QUESTIONS;";
	std::list<Question> questions;
	int i = 0;

	auto callback = [](void* data, int argc, char** argv, char** azColName) -> int {
		std::list<Question>* questions = static_cast<std::list<Question>*>(data);
		std::string que = argv[1];
		std::string firAns = argv[2];
		std::string secAns = argv[3];
		std::string thirdAns = argv[4];
		std::string fourthAns = argv[5];
		int ansId = std::stoi(argv[6]);
		std::vector<std::string> ans;
		ans.push_back(firAns);
		ans.push_back(secAns);
		ans.push_back(thirdAns);
		ans.push_back(fourthAns);
		questions->push_back(*new Question(que, ans, ansId));
		return 0;
	};

	bool succ = this->sentRequest(query, &questions, callback);
	if (succ == false)
	{
		throw std::invalid_argument("an error has occued getting the 5 highest scores");
	}

	for (auto last = questions.end(); i != questions.size() - numQuestions; last--)
	{
		questions.erase(last);
	}

	return questions;
}

float SqliteDatabase::getPlayerAverageAnswerTime(const std::string& userName)
{
	std::string query = "SELECT avgTime FROM PLAYERS WHERE playerName = '?';";
	int avgTime = -1; // the average time
	size_t pos = query.find("?");
	query.replace(pos, 1, userName);

	auto callback = [](void* data, int argc, char** argv, char** azColName) -> int {
		int* avgTime = static_cast<int*>(data);
		return 0;
	};

	bool succ = sentRequest(query, &avgTime, callback);
	if (succ == false)
	{
		throw DBException("an error has occued getting average answer time from user " + userName);
	}
	return avgTime;
}

int SqliteDatabase::getNumOfCorrectAnswers(const std::string& userName)
{
	std::string query = "SELECT numCorrectAns FROM PLAYERS WHERE playerName = '?';";
	int numCorrAns = -1; // the number of correct answers
	size_t pos = query.find("?");
	query.replace(pos, 1, userName);

	auto callback = [](void* data, int argc, char** argv, char** azColName) -> int {
		int* numCorrAns = static_cast<int*>(data);
		return 0;
	};

	bool succ = sentRequest(query, &numCorrAns, callback);
	if (succ == false)
	{
		throw DBException("an error has occued getting number of correct answers from user " + userName);
	}
	return numCorrAns;
}

int SqliteDatabase::getNumOfTotalAnswers(const std::string& userName)
{
	std::string query = "SELECT numQueAnswered FROM PLAYERS WHERE playerName = '?';";
	int numQuestionsAnswered = -1; // the number of questions answered
	size_t pos = query.find("?");
	query.replace(pos, 1, userName);

	auto callback = [](void* data, int argc, char** argv, char** azColName) -> int {
		int* numQuestionsAnswered = static_cast<int*>(data);
		return 0;
	};

	bool succ = sentRequest(query, &numQuestionsAnswered, callback);
	if (succ == false)
	{
		throw DBException("an error has occued getting average answer time from user " + userName);
	}
	return numQuestionsAnswered;
}

int SqliteDatabase::getNumOfPlayerGames(const std::string& userName)
{
	std::string query = "SELECT numGames FROM PLAYERS WHERE playerName = '?';";
	int numGamesPlayed = -1; // the number of games the user has played
	size_t pos = query.find("?");
	query.replace(pos, 1, userName);

	auto callback = [](void* data, int argc, char** argv, char** azColName) -> int {
		int* numGamesPlayed = static_cast<int*>(data);
		return 0;
	};

	bool succ = sentRequest(query, &numGamesPlayed, callback);
	if (succ == false)
	{
		throw DBException("an error has occued getting average answer time from user " + userName);
	}
	return numGamesPlayed;
}

void SqliteDatabase::addTables()
{
	sentRequest(R"(
    CREATE TABLE USERS (
        id INTEGER PRIMARY KEY,
        userName TEXT UNIQUE NOT NULL,
        password TEXT NOT NULL,
        email TEXT NOT NULL
    ); )");
}

void SqliteDatabase::deleteDataBase()
{
	std::string request = "DROP TABLE IF EXISTS USERS;";
	sentRequest(request);
	addTables();
}

std::vector<std::string> SqliteDatabase::getHighScores()
{
	std::string query = "SELECT playerName FROM PLAYERS ORDER BY score DESC LIMIT 5";
	std::vector<std::string> records;

	auto callback = [](void* data, int argc, char** argv, char** azColName) -> int {
		std::vector<std::string>* recordes = static_cast<std::vector<std::string>*>(data);
		std::string name = argv[0];
		recordes->push_back(name);
		return 0;
	};

	bool succ = this->sentRequest(query, &records, callback);
	if (succ == false)
	{
		throw std::invalid_argument("an error has occued getting the 5 highest scores");
	}
	return records;
}

std::vector<std::string> SqliteDatabase::getUserStatistics(const std::string& username)
{
	std::string query = "SELECT score, numCorrectAns FROM PLAYERS WHERE playerName = '?';";
	std::pair<int, int> pair = std::pair<int, int>(-1, -1);
	size_t pos = query.find("?");
	query.replace(pos, 1, username);

	auto callback = [](void* data, int argc, char** argv, char** azColName) -> int {
		std::pair<int, int>* pair = static_cast<std::pair<int, int>*>(data);
		pair->first = std::stoi(argv[0]);
		pair->second = std::stoi(argv[1]);
		return 0;
	};

	bool succ = this->sentRequest(query, &pair, callback);
	if (succ == false)
	{
		throw std::invalid_argument("an error has occued getting the 5 highest scores");
	}

	// converting the pair of score and number of correct answers to a vector
	std::vector<std::string> userStats;
	userStats.push_back(std::to_string(pair.first));
	userStats.push_back(std::to_string(pair.second));
	return userStats;
}

