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
            b.InitGame();
        }
    }
}
