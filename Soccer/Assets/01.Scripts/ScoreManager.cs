using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
            if (instance != null)
            {
                Debug.LogError("Multiple ScoreManager Running");
            }
            instance = FindObjectOfType<ScoreManager>();
            return instance;
        }
    }

    private int myScore;
    private int enemyScore;

    public void IncreaseScore(int amount, bool isEnemy)
    {
        if (isEnemy)
        {
            enemyScore += amount;
        }
        else
        {
            myScore += amount;
        }
    }

    public int GetScore() => myScore;
    public int GetEnemyScore() => enemyScore;
}
