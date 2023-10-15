using QWER.NETWORK;
using System.Net;
using System;

namespace Server
{
    public class ClientSession : Session
    {
        public override void OnConnected(EndPoint endPoint)
        {
            Console.WriteLine($"{endPoint} 연결했슈");
        }

        public override void OnDisconnected(EndPoint endPoint)
        {
            Console.WriteLine($"{endPoint} 나갔슈");
        }

        public override void OnPacketReceived(ArraySegment<byte> buffer)
        {
            Console.WriteLine($"{buffer.Count} : 받음!");
            PacketManager.Instance.HandlePacket(this, PacketManager.Instance.CreatePacket(buffer));
        }

        public override void OnSent(int length)
        {
            Console.WriteLine($"{length} : 데이터 보냄!");
        }
    }
}
