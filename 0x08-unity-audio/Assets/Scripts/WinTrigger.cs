using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject Player;
    public AudioSource CamAudio;

    private void OnTriggerEnter(Collider collision)
    {
        Player.GetComponent<Timer>().enabled = false;
        CamAudio.Stop();
    }
}
