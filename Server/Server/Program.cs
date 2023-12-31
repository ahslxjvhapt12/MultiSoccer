﻿using QWER.NETWORK;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;


namespace Server
{
    public class Program
    {
        public static GameRoom room = new GameRoom();
        public static Dictionary<ushort, Player> players = new Dictionary<ushort, Player>();
        public static ushort playerCount = 0;

        public static void Main(string[] args)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("172.31.2.230"), 8081);

            Listener listener = new Listener(endPoint);
            if (listener.Listen(10))
                listener.StartAccept(OnAccepted);

            FlushLoop(10);
        }

        private static void FlushLoop(int delay)
        {
            int lastFlushTime = Environment.TickCount;

            while (true)
            {
                int currentTime = Environment.TickCount;
                if (currentTime - lastFlushTime > delay)
                {
                    room.AddJob(() => room.FlushPacketQueue());
                    lastFlushTime = currentTime;
                }
            }
        }

        private static void OnAccepted(Socket socket)
        {
            ClientSession session = new ClientSession();
            session.Open(socket);
            session.OnConnected(socket.RemoteEndPoint);
        }
    }
}