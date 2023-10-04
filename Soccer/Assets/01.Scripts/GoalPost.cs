using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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
        if(collision.attachedRigidbody.TryGetComponent<Ball>(out Ball b)){
            score++;
            ScoreTXT.text = score.ToString();
            b.InitializePosition();
        }
    }
}
