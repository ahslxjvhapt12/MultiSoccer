using Packets;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigid;

    [Header("Networks")]
    [SerializeField] float syncDelay = 0.02f;
    [SerializeField] float syncDistanceErr = 0.1f;
    private float lastSyncTime = 0f;
    private Vector3 lastSyncPosition = Vector3.zero;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        if (lastSyncTime + syncDelay > Time.time)
            return;

        if ((lastSyncPosition - transform.position).sqrMagnitude < syncDistanceErr * syncDistanceErr)
            return;

        PlayerPacket playerData = new PlayerPacket();
        playerData.playerID = (ushort)GameManager.Instance.PlayerID;
        playerData.x = -transform.position.x;
        playerData.y = transform.position.y;

        C_BallMovePacket packet = new C_BallMovePacket();
        packet.playerData = playerData;

        NetworkManager.Instance.Send(packet);

        lastSyncPosition = transform.position;
        lastSyncTime = Time.time;
    }

    [ContextMenu("Init Game")]
    public void InitGame()
    {
        GameObject player = GameObject.Find("Player_Blue");
        OtherPlayer otherPlayer = GameObject.FindObjectOfType<OtherPlayer>();

        player.transform.position = new Vector3(-5, -2, 0);
        otherPlayer.transform.position = new Vector3(5, -2, 0);
        
        transform.position = Vector3.zero;
        _rigid.velocity = Vector3.zero;
        _rigid.AddForce(Vector2.up * 0.5f, ForceMode2D.Impulse);
    }
}
