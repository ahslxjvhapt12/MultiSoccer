using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Player
    {
        public ushort playerID;
        public string nickname;
        public float x;
        public float y;
        public float z;

        public ClientSession session;

        public Player(ClientSession session, ushort playerID, string nickname, float x, float y, float z)
        {
            this.session = session;
            this.playerID = playerID;
            this.nickname = nickname;
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
