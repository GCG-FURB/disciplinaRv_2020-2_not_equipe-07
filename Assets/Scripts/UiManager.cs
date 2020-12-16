using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public Text scoreText;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateScoreText(int amount)
    {
        scoreText.text = $"Score: {amount:D10}";
    }
}
