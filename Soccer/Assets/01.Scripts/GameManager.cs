using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerMove otherPlayer;
    public int PlayerID = -1;
    
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

    private Dictionary<ushort, PlayerMove> otherPlayers = new Dictionary<ushort, PlayerMove>();

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
    }

    public PlayerMove GetPlayer(ushort id)
    {
        Debug.Log($"Other Players Count : {otherPlayers.Count}");
        Debug.Log($"Requested Player ID : {id}");

        if (otherPlayers.ContainsKey(id))
            return otherPlayers[id];
        else
            return null;
    }
}
