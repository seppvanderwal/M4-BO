using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    string scoreKey = "score";
    public int CurrentScore { get; set; }
    // Start is called before the first frame update
    private void Aqake()
    {
        CurrentScore = PlayerPrefs.GetInt(scoreKey);
    }

    public void SetScore(int score) 
    {
        PlayerPrefs.SetInt(scoreKey, score); 
    }
}
