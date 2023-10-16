using TMPro;
using UnityEngine;

public class GoalPost : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreTXT;
    private int score;

    private void Start()
    {
        score = 0;
        ScoreTXT.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.TryGetComponent<Ball>(out Ball b))
        {
            Debug.Log("°ñ");
            score++;
            ScoreTXT.text = score.ToString();

            C_GoalPacket goalPacket = new C_GoalPacket();
            goalPacket.playerID = (ushort)GameManager.Instance.PlayerID;

            NetworkManager.Instance.Send(goalPacket);
            //b.InitGame();
        }
    }
}
