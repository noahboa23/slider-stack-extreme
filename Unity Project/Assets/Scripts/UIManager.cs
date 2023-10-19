using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timerText;

    void Start()
    {
        scoreText.text = "Score: " + 0;
        //timerText.text = "30";
    }

    public void UpdateTimerText(int timer)
    {
        timerText.text = timer.ToString();
    }


    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
