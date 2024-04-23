using sandboxGUI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sandboxGUI
{
    struct ErrorResponse
    {
        public ErrorResponse(dynamic jsonObject)
        {
            err = jsonObject.status;
        }

        public String err;
    }
    struct LoginResponse
    {
        public LoginResponse(dynamic jsonObject)
        {
            status = jsonObject.status;
        }

        public uint status;
    }


    struct SignupResponse
    {
        public SignupResponse(dynamic jsonObject)
        {
            status = jsonObject.status;
        }

        public uint status;
    }

    struct LogoutResponse
    {
        uint status;
    };

    struct GetRoomsResponse
    {
        public GetRoomsResponse(dynamic jsonObject)
        {
            status = jsonObject.status;

            rooms = new List<RoomData>();
            if (jsonObject.ContainsKey("rooms"))
            {
                foreach (dynamic roomObject in jsonObject.rooms)
                {
                    RoomData room = new RoomData
                    {
                        name = roomObject.name,
                        isActive = roomObject.isActive,
                        maxPlayers = roomObject.maxPlayers,
                        numOfQuestionsInGame = roomObject.numOfQuestionsInGame,
                        id = roomObject.roomId,
                        timePerQuestion = roomObject.timePerQuestion
                    };

                    rooms.Add(room);
                }
            }
            
        }
        public uint status;
        public List<RoomData> rooms;
    };

    struct GetPlayersInRoomResponse
    {
        public GetPlayersInRoomResponse(dynamic jsonObject)
        {
            players = new List<string>();

            foreach (String player in jsonObject.players)
            {
                players.Add(player);
            }
        }
        public List<string> players;
    };

    struct getHighScoreResponse
    {
        uint status;
        List<string> statistics;
    };

    struct getPersonalStatsResponse
    {
        public uint status;
        public List<string> statistics;
    };

    struct JoinRoomResponse
    {
        public JoinRoomResponse(dynamic jsonObject)
        {
            status = jsonObject.status;
        }
        public uint status;
    };

    struct CreateRoomResponse
    {
        public CreateRoomResponse(dynamic jsonObject)
        {
            status = jsonObject.status;
        }
        public uint status;
    };

    struct GetRoomStateResponse
    {
        public GetRoomStateResponse(dynamic jsonObject)
        {
            status = jsonObject.status;
            hasGameBegun = jsonObject.hasGameBegun;

            players = new List<string>();
            foreach (String player in jsonObject.players)
            {
                players.Add(player);
            }

            questionsCount = jsonObject.AnswerCount;
            answerTimeout = jsonObject.answerTimeOut;
        }


        public uint status;
        public bool hasGameBegun;
        public List<string> players;
        public uint questionsCount;
        public uint answerTimeout;
    }

    struct LeaveRoomResponse
    {
        public LeaveRoomResponse(dynamic jsonObject)
        {
            status = jsonObject.status;
        }

        public uint status;
    }

    struct StartGameResponse
    {
        public StartGameResponse(dynamic jsonObject)
        {
            status = jsonObject.status;
        }

        public uint status;
    }

    struct GetQuestionResponse
    {
        public GetQuestionResponse(dynamic jsonObject)
        {
            status = jsonObject.status;
            question = jsonObject.question;
            answers = new Dictionary<uint, string>();

            foreach (var answer in jsonObject.map_answer)
            {
                uint key = answer.First;
                string value = answer.Last;
                answers.Add(key, value);
            }
        }

        public uint status;
        public string question;
        public Dictionary<uint, string> answers;
    }

    struct SubmitAnswerResponse
    {
        public SubmitAnswerResponse(dynamic jsonObject)
        {
            status = jsonObject.status;
            correctAnswerId = jsonObject.correctAnswerId;
        }

        public uint status;
        public uint correctAnswerId;
    }
}
