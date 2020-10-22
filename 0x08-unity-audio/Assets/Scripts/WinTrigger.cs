using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject Player;
    public AudioSource CamAudio;
    AudioSource victory;

    void Start()
    {
        victory = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        Player.GetComponent<Timer>().enabled = false;
        CamAudio.Stop();
        victory.Play();
    }
}
