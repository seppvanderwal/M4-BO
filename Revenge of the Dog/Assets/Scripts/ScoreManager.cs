using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    string scoreKey = "score";
    public int score;
    public TextMeshProUGUI scoreText;

    public int CurrentScore { get; set; }
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
        CurrentScore = PlayerPrefs.GetInt(scoreKey);
    }

    public void SetScore(int score) 
    {
        PlayerPrefs.SetInt(scoreKey, score); 
    }


    public void AddPoint(Player player)
    {
        score++;
        scoreText.text = score.ToString("0");
    }
}
