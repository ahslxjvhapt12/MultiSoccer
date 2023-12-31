using Packets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.Find("GameManager")?.GetComponent<GameManager>();
            return instance;
        }
    }

    private Dictionary<ushort, OtherPlayer> otherPlayers = new Dictionary<ushort, OtherPlayer>();

    [SerializeField] public PhysicsMaterial2D mat;
    [SerializeField] OtherPlayer playerPrefab;
    public int PlayerID = -1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
            return;
        }

        NetworkManager.Instance = gameObject.AddComponent<NetworkManager>();
        SceneLoader.Instance = gameObject.AddComponent<SceneLoader>();
    }

    public void AddPlayer(PlayerPacket p)
    {
        //OtherPlayer player = Instantiate(playerPrefab, new Vector3(p.x, p.y, 0), Quaternion.identity);
        OtherPlayer player = Instantiate(playerPrefab, new Vector3(5, -2, 0), Quaternion.identity);
        otherPlayers.Add(p.playerID, player);
    }

    public OtherPlayer GetPlayer(ushort id)
    {
        Debug.Log($"Other Players Count : {otherPlayers.Count}");
        Debug.Log($"Requested Player ID : {id}");

        if (otherPlayers.ContainsKey(id))
            return otherPlayers[id];
        else
            return null;
    }
}
