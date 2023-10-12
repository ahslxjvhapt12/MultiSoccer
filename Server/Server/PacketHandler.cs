using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QWER.NETWORK;
using Packets;

namespace Server
{
    public class PacketHandler
    {
        public static void C_LogInPacket(Session session, Packet packet) // Client로부터 ChatPacket을 받았을 때
        {
            C_LogInPacket loginPacket = packet as C_LogInPacket;
            ClientSession clientSession = session as ClientSession;

            Player player = new Player(clientSession, Program.playerCount, loginPacket.nickname, 0, 0, 0);
            Program.players.Add(player.playerID, player);

            Program.playerCount++;

            S_LogInPacket sendPacket = new S_LogInPacket();
            sendPacket.playerID = player.playerID;

            clientSession.Send(sendPacket.Serialize());
        }

        public static void C_RoomEnterPacket(Session session, Packet packet)
        {

        }

        public static void C_MovePacket(Session session, Packet packet)
        {

        }
    }
}
