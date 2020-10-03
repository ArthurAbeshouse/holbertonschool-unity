using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerExit(Collider collision)
    {
        Player.GetComponent<Timer>().enabled = true;
    }
}
