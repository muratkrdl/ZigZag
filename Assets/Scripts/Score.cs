using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int increaseScoreAmount = 1;
    public int score;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void IncreaseScore()
    {
        score += increaseScoreAmount;
    }

}
