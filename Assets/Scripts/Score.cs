using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int CurrentScore;
    public Text ScoreText;
    private void OnTriggerEnter(Collider other)
    {
        AddScore();
    }

    void AddScore()
    {
        CurrentScore++;
        ScoreText.text = CurrentScore.ToString();
    }
}
