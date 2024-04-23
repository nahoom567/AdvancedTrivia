using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace sandboxGUI
{
    internal static class Serialization
    {
        public enum ResponseCode
        {
            login = 2,
            signup = 3,
            logout = 4,
            getRooms = 5,
            getPlayers = 6,
            joinRoom = 7,
            createRoom = 8,
            getHighScore = 9,
            getPersonalScore = 10,
            closeRoom = 11,
            startGame = 12,
            getRoomState = 13,
            leaveRoom = 14,
            leaveGame = 15,
            getQuestions = 16,
            submitAnswers = 17,
            getGameResults = 18
        };

        public static byte[] serialize(String data, int code)
        {
            byte[] msgToServer = new byte[data.Length + protocolCodeLength + protocolMsgSizeLength];

            // putting in the first byte of the protocoled msg to the user the code of the msg:
            msgToServer[0] = (byte)code;

            // putting in the next 4 bytes the length of the msg:
            byte[] lengthBytes = BitConverter.GetBytes(data.Length);
            Array.Reverse(lengthBytes);
            Array.Copy(lengthBytes, 0, msgToServer, 1, 4);

            // putting the json data:
            Array.Copy(Encoding.UTF8.GetBytes(data), 0, msgToServer, 5, data.Length);

            return msgToServer;
        }
        public static object deserialize(Tuple<int, byte[]> data)
        {
            String jsonString = Encoding.UTF8.GetString(data.Item2);
            dynamic jsonObject = JsonConvert.DeserializeObject(jsonString);

            if (m_responseTypes.TryGetValue(data.Item1, out Type responseType))
            {
                object response = Activator.CreateInstance(responseType, jsonObject);
                return response;
            }

            throw new Exception("there is an unknow code number for the msg");
        }

        
        private static readonly Dictionary<int, Type> m_responseTypes = new Dictionary<int, Type>
        {
            { 1, typeof(ErrorResponse) },
            { 2, typeof(LoginResponse)},
            { 3, typeof(SignupResponse)},
            { 4, typeof(LogoutResponse) },
            { 5, typeof(GetRoomsResponse) },
            { 6, typeof(GetPlayersInRoomResponse) },
            { 7, typeof(JoinRoomResponse) },
            { 8, typeof(CreateRoomResponse) },
            { 9, typeof(getHighScoreResponse) },
            { 10, typeof(getPersonalStatsResponse) },
            { 12, typeof(StartGameResponse) },
            { 13, typeof(GetRoomStateResponse)},
            { 14, typeof(LeaveRoomResponse) },
            { 16, typeof(GetQuestionResponse) },
            { 17, typeof(SubmitAnswerResponse) }
        };
        private const int protocolCodeLength = 1;
        private const int protocolMsgSizeLength = 4;

    }
}
