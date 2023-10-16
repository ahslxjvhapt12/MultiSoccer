using Packets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBall : MonoBehaviour
{
    public void SetPosition(PlayerPacket playerData)
    {
        Vector3 pos = transform.position;
        pos.x = playerData.x;
        pos.y = playerData.y;

        transform.position = pos;
    }
}
