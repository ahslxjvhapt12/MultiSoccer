using Packets;
using QWER.NETWORK;
using Unity.VisualScripting;
using UnityEngine;

public class PacketHandler
{
    public static void S_LogInPacket(Session session, Packet packet)
    {
        S_LogInPacket logInPacket = packet as S_LogInPacket;
        GameManager.Instance.PlayerID = logInPacket.playerID;

        GameObject.Find("Canvas/LoginPanel").SetActive(false);
    }

    public static void S_MovePacket(Session session, Packet packet)
    {
        S_MovePacket movePacket = packet as S_MovePacket;
        PlayerPacket playerData = movePacket.playerData;

        OtherPlayer player = GameManager.Instance.GetPlayer(playerData.playerID);
        Debug.Log($"Player : {player}");
        player?.SetPosition(playerData);
    }

    public static void S_PlayerJoinPacket(Session session, Packet packet)
    {
        S_PlayerJoinPacket joinPacket = packet as S_PlayerJoinPacket;
        GameManager.Instance.AddPlayer(joinPacket.playerData);
    }

    public static void S_RoomEnterPacket(Session session, Packet packet)
    {
        S_RoomEnterPacket enterPacket = packet as S_RoomEnterPacket;

        SceneLoader.Instance.LoadSceneAsync("MainScene", () =>
        {
            if (GameManager.Instance.PlayerID == 0)
            {
                GameObject.FindObjectOfType<DummyBall>().AddComponent<Ball>();
            }
            enterPacket.playerList.ForEach(GameManager.Instance.AddPlayer);
        });
    }

    public static void S_KickPacket(Session session, Packet packet)
    {
        Debug.Log("KickPacket 받음");
        //GameObject.Find("OtherPlayer").GetComponent<OtherPlayer>().Kick();
        GameObject.FindObjectOfType<OtherPlayer>().Kick();
    }

    public static void S_BallMovePacket(Session session, Packet packet)
    {
        S_BallMovePacket movePacket = packet as S_BallMovePacket;
        PlayerPacket playerData = movePacket.playerData;

        GameObject.Find("Ball").GetComponent<DummyBall>().SetPosition(playerData);
    }

    public static void S_GoalPacket(Session session, Packet packet)
    {
        Debug.Log("GoalPacket 받음");
        GameObject.FindObjectOfType<GoalEvent>().Goal();
    }
}
