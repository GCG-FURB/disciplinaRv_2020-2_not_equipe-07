using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int score = 0;

    void Awake()
    {
        instance = this;
    }

    public int ReadScore() => score;

    public void AddScore(int score)
    {
        this.score += score;
        UiManager.instance.UpdateScoreText(this.score);
    }

}
