using Packets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    /// <summary>
    /// 게임 시작
    /// </summary>
    public void StartGame()
    {
        if (GameManager.Instance.PlayerID < 0)
            return;

        C_RoomEnterPacket packet = new C_RoomEnterPacket();
        packet.playerID = (ushort)GameManager.Instance.PlayerID;

        NetworkManager.Instance.Send(packet);
    }
}
