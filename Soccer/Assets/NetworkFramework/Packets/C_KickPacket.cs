using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QWER.NETWORK;
using System;
using Packets;

public class C_KickPacket : Packet
{
    public override ushort ID => (ushort)PacketID.C_KickPacket;

    public ushort playerID;

    public override void Deserialize(ArraySegment<byte> buffer)
    {
        ushort process = 0;

        process += sizeof(ushort);
        process += sizeof(ushort);
        process += PacketUtility.ReadUShortData(buffer, process, out playerID);
    }

    public override ArraySegment<byte> Serialize()
    {
        ArraySegment<byte> buffer = UniqueBuffer.Open(1024);
        ushort process = 0;

        process += sizeof(ushort);
        process += PacketUtility.AppendUShortData(this.ID, buffer, process);
        process += PacketUtility.AppendUShortData(this.playerID, buffer, process);
        PacketUtility.AppendUShortData(process, buffer, 0);

        return UniqueBuffer.Close(process);
    }
}
