using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandboxGUI.Data
{
    public struct RoomData
    {
        public string name { get; set; }
        public uint id { get; set; }
        public uint maxPlayers { get; set; }
        public uint numOfQuestionsInGame { get; set; }
        public uint timePerQuestion { get; set; }
        public uint isActive { get; set; }
    }
}
