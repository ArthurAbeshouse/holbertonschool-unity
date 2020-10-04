using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public PlayerController Player;
    public GameObject MainCamera;
    public GameObject Timer;

    public float delayTime;
   // private PlayerScript PS;

    // Start is called before the first frame update
    void Start()
    {
        //PS = Player.GetComponent<PlayerController>();
        StartCoroutine(Begin(delayTime));
    }

    IEnumerator Begin(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        MainCamera.SetActive(true);
        Timer.SetActive(true);
        Player.enabled = true;
        transform.gameObject.SetActive(false);
    }
}
