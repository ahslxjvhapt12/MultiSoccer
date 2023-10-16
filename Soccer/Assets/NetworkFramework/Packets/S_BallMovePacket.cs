using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QWER.NETWORK;
using System;
using Packets;

public class S_BallMovePacket : Packet
{
    public override ushort ID => (ushort)PacketID.S_BallMovePacket;

    public PlayerPacket playerData;

    public override void Deserialize(ArraySegment<byte> buffer)
    {
        ushort process = 0;

        process += sizeof(ushort);
        process += sizeof(ushort);

        process += PacketUtility.ReadDataPacket<PlayerPacket>(buffer, process, out playerData);
    }

    public override ArraySegment<byte> Serialize()
    {
        ArraySegment<byte> buffer = UniqueBuffer.Open(1024);
        ushort process = 0;

        process += sizeof(ushort);
        process += PacketUtility.AppendUShortData(this.ID, buffer, process);
        process += PacketUtility.AppendDataPacket<PlayerPacket>(this.playerData, buffer, process);
        PacketUtility.AppendUShortData(process, buffer, 0);

        return UniqueBuffer.Close(process);
    }

}
