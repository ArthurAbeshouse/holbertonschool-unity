using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText, FinalTime;

    public GameObject WinCanvas;

    private float milliseconds, seconds, minutes, timerTime, beginningTime;

    private bool startTimer = true;

    void Start()
    {
        beginningTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timerTime = 0 + (Time.time - beginningTime);
        minutes = (int)(timerTime / 60f);
        seconds = (int)(timerTime % 60f);
        milliseconds = (int)(timerTime * 100f) % 100;

        if (startTimer)
        {
            TimerText.text = minutes.ToString("0") + ":" + seconds.ToString("00") + "." + milliseconds.ToString("00");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WinFlag")
        {
            startTimer = false;
            Time.timeScale = 0;
            /* TimerText.text = minutes.ToString("0") + ":" + seconds.ToString("00") + "." + milliseconds.ToString("00");
             TimerText.fontSize = 60;
             TimerText.color = Color.green; */
            WinCanvas.SetActive(true);
            Win();
        }
    }

    public void Win()
    {
        FinalTime.text = minutes.ToString("0") + ":" + seconds.ToString("00") + "." + milliseconds.ToString("00");
    }
}
