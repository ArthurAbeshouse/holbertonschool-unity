using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider collision)
    {
        Player.GetComponent<Timer>().enabled = false;
    }
}
