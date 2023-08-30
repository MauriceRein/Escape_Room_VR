using System;
using UnityEngine;
using TMPro;

public class CountdownUhr : MonoBehaviour
{
    //display timer
    public TMP_Text timerText;

    //10 min
    private float totalTime = 900f; 
    private float elapsedTime;

    private void Start()
    {
        elapsedTime = totalTime;
        UpdateTimerText();
    }

    private void Update()
    //update the watch
    {
        if (elapsedTime > 0f)
        {
            //subtract time each second
            elapsedTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            //IF The timer reaches 0 seconds, make a log
            Debug.Log("Timer has reached 0!");
        }
    }

    private void UpdateTimerText()
    {   

        //time format so that we have minutes shown
        TimeSpan time = TimeSpan.FromSeconds(elapsedTime);
        string timerString = string.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
        timerText.text = timerString;
    }
}