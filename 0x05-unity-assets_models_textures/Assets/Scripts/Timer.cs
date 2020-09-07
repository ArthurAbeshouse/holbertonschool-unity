using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;

    public float milliseconds, seconds, minutes;

    private bool startTimer = true;

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            minutes = (int)(Time.time / 60f);
            seconds = (int)(Time.time % 60f);
            milliseconds = (int)(Time.time * 100f) % 100;
            TimerText.text = minutes.ToString("0") + ":" + seconds.ToString("00") + "." + milliseconds.ToString("00");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WinFlag")
        {
            startTimer = false;
            TimerText.text = minutes.ToString("0") + ":" + seconds.ToString("00") + "." + milliseconds.ToString("00");
            TimerText.fontSize = 60;
            TimerText.color = Color.green;
        }
    }
}
