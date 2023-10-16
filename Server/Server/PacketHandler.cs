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
        public static void C_LogInPacket(Session session, Packet packet) // Client로부터 LogInPacket을 받았을 때
        {
            C_LogInPacket loginPacket = packet as C_LogInPacket;
            ClientSession clientSession = session as ClientSession;

            Player player = new Player(clientSession, Program.playerCount, loginPacket.nickname, 0, 0);
            Program.players.Add(player.playerID, player);
            Program.playerCount++;

            S_LogInPacket sendPacket = new S_LogInPacket();
            sendPacket.playerID = player.playerID;

            clientSession.Send(sendPacket.Serialize());
        }

        public static void C_RoomEnterPacket(Session session, Packet packet)
        {
            C_RoomEnterPacket enterPacket = packet as C_RoomEnterPacket;

            GameRoom room = Program.room;
            room.AddJob(() => room.AddPlayer(enterPacket.playerID));

            S_RoomEnterPacket resPacket = new S_RoomEnterPacket();
            resPacket.playerList = new List<PlayerPacket>();
            room.players.ForEach(p =>
            {
                if (p == enterPacket.playerID)
                    return;

                Console.WriteLine($"현재 플레이어 아이디 : {p}");

                Player player = Program.players[p];
                PlayerPacket playerPacket = new PlayerPacket(player.playerID, player.x, player.y);
                resPacket.playerList.Add(playerPacket);
            });
            session.Send(resPacket.Serialize());

            Player player = Program.players[enterPacket.playerID];
            S_PlayerJoinPacket broadcastPacket = new S_PlayerJoinPacket();
            broadcastPacket.playerData = new PlayerPacket(player.playerID, player.x, player.y);

            room.AddJob(() => room.Broadcast(broadcastPacket, player.playerID));
        }

        public static void C_MovePacket(Session session, Packet packet)
        {
            C_MovePacket movePacket = packet as C_MovePacket;
            GameRoom room = Program.room;

            Player player = room.GetPlayer(movePacket.playerData.playerID);
            if (player == null)
                return;
            player.x = movePacket.playerData.x;
            player.y = movePacket.playerData.y;

            S_MovePacket resPacket = new S_MovePacket();
            resPacket.playerData = new PlayerPacket(player.playerID, player.x, player.y);

            room.Broadcast(resPacket, movePacket.playerData.playerID);
        }

        public static void C_KickPacket(Session session, Packet packet)
        {
            C_KickPacket kickPacket = packet as C_KickPacket;
            GameRoom room = Program.room;

            S_KickPacket s_KickPacket = new S_KickPacket();
            room.Broadcast(s_KickPacket, kickPacket.playerID);
        }

        public static void C_BallMovePacket(Session session, Packet packet)
        {
            C_BallMovePacket movePacket = packet as C_BallMovePacket;
            GameRoom room = Program.room;

            S_BallMovePacket resPacket = new S_BallMovePacket();
            resPacket.playerData = new PlayerPacket(movePacket.playerData.playerID, movePacket.playerData.x, movePacket.playerData.y);

            room.Broadcast(resPacket, movePacket.playerData.playerID);
        }

        public static void C_GoalPacket(Session session, Packet packet)
        {
            C_GoalPacket goalPacket = packet as C_GoalPacket;
            GameRoom room = Program.room;

            S_GoalPacket resPacket = new S_GoalPacket();
            resPacket.playerID = goalPacket.playerID;

            room.Broadcast(resPacket, ushort.MaxValue);
        }
    }
}
