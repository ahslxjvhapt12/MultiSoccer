using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QWER.NETWORK;
using System.Net;
using System;

public class ServerSession : Session
{
    public override void OnConnected(EndPoint endPoint)
    {
        Debug.Log($"{endPoint} : ���� ����!");
        NetworkManager.Instance.IsConnect = true;
    }

    public override void OnDisconnected(EndPoint endPoint)
    {
        Debug.Log($"{endPoint} : ���� ��������!");
        NetworkManager.Instance.IsConnect = false;
    }

    public override void OnPacketReceived(ArraySegment<byte> buffer)
    {
        Debug.Log($"{buffer.Count} : ������ ����!");
        Packet packet = PacketManager.Instance.CreatePacket(buffer);
        NetworkManager.Instance.PushPacket(packet);
    }

    public override void OnSent(int length)
    {
        Debug.Log($"{length} : ������ ����!");
    }
}
