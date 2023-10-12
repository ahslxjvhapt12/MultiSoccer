using QWER.NETWORK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class PacketManager
    {
        private static PacketManager instance;
        public static PacketManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new PacketManager();
                return instance;
            }
        }

        private Dictionary<ushort, Func<ArraySegment<byte>, Packet>> packetFactories = new Dictionary<ushort, Func<ArraySegment<byte>, Packet>>(); // 패킷 생성자
        private Dictionary<ushort, Action<Session, Packet>> packetHandlers = new Dictionary<ushort, Action<Session, Packet>>(); // 패킷 핸들러

        public PacketManager()
        {
            packetFactories.Clear();
            packetHandlers.Clear();
        }

        private void RegisterHandler() // 핸들러 구독
        {

        }

        public Packet CreatePacket(ArraySegment<byte> buffer)
        {
            ushort packetID = PacketUtility.ReadPacketID(buffer);
            if (packetFactories.ContainsKey(packetID))
                return packetFactories[packetID]?.Invoke(buffer);
            else
                return null;
        }

        public void HandlePacket(Session session, Packet packet)
        {
            if (packet != null)
                if (packetHandlers.ContainsKey(packet.ID)) // 핸들러가 존재하면
                    packetHandlers[packet.ID]?.Invoke(session, packet); // 패킷 핸들링
        }
    }
}
