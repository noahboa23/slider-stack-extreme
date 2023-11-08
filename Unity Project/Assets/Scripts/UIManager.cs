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
        string minutes = (timer / 60).ToString();
        string seconds = (timer % 60).ToString();
        if((timer % 60) < 10){
            seconds = "0" + seconds;
        }
        timerText.text = minutes + ":" + seconds;
    } 


    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
