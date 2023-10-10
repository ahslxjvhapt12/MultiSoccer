using H00N.Network;
using Packets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Dictionary<ushort, Func<ArraySegment<byte>, Packet>> packetFactories = new Dictionary<ushort, Func<ArraySegment<byte>, Packet>>(); // ��Ŷ ������
    private Dictionary<ushort, Action<Session, Packet>> packetHandlers = new Dictionary<ushort, Action<Session, Packet>>(); // ��Ŷ �ڵ鷯


    public PacketManager()
    {
        // �������� �ʱ�ȭ
        packetFactories.Clear();
        packetHandlers.Clear();

        RegisterHandler(); // �ڵ鷯 ����
    }

    private void RegisterHandler() // �ڵ鷯 ����
    {
        packetFactories.Add((ushort)PacketID.S_LogInPacket, PacketUtility.CreatePacket<S_LogInPacket>);
        packetHandlers.Add((ushort)PacketID.S_LogInPacket, PacketHandler.S_LogInPacket);
        packetFactories.Add((ushort)PacketID.S_MovePacket, PacketUtility.CreatePacket<S_MovePacket>);
        packetHandlers.Add((ushort)PacketID.S_MovePacket, PacketHandler.S_MovePacket);
        packetFactories.Add((ushort)PacketID.S_PlayerJoinPacket, PacketUtility.CreatePacket<S_PlayerJoinPacket>);
        packetHandlers.Add((ushort)PacketID.S_PlayerJoinPacket, PacketHandler.S_PlayerJoinPacket);
        packetFactories.Add((ushort)PacketID.S_RoomEnterPacket, PacketUtility.CreatePacket<S_RoomEnterPacket>);
        packetHandlers.Add((ushort)PacketID.S_RoomEnterPacket, PacketHandler.S_RoomEnterPacket);
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
            if (packetHandlers.ContainsKey(packet.ID)) // �ڵ鷯�� �����ϸ�
                packetHandlers[packet.ID]?.Invoke(session, packet); // ��Ŷ �ڵ鸵
    }
}