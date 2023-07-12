using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSingleton : MonoBehaviour
{
    #region Singleton
    public static ScoreSingleton Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion


    private int score;
    public TMP_Text scoreText;

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }
}
