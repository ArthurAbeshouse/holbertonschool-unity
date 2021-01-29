using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class UI_Manager : MonoBehaviour
{
    public GameObject Play_Again_btn;
    public GameObject Reset_btn;
    public GameObject Exit_btn;
    public GameObject Start_btn;
    public GameObject Score_txt;
    public GameObject GameOver_msg;
    public GameObject Ammo_txt;
    public GameObject Surface_msg;

    private ARSession aRSession;

    // Start is called before the first frame update
    private void Start()
    {
        aRSession = FindObjectOfType<ARSession>();
    }

    public void StartGameUI()
    {
        Play_Again_btn.SetActive(false);
        Reset_btn.SetActive(true);
        Exit_btn.SetActive(true);
        Start_btn.SetActive(false);
        Surface_msg.SetActive(false);
        GameOver_msg.SetActive(false);
        Score_txt.SetActive(true);
        Ammo_txt.SetActive(true);
        Score_txt.GetComponent<Text>().text = "0";
    }

    public void GameOverUI()
    {
        Play_Again_btn.SetActive(true);
        Reset_btn.SetActive(true);
        Exit_btn.SetActive(true);
        Start_btn.SetActive(false);
        Surface_msg.SetActive(false);
        GameOver_msg.SetActive(true);
        Score_txt.SetActive(true);
        Ammo_txt.SetActive(false);
    }

    public void ResetSession()
    {
        aRSession.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AmmoCount()
    {
        GameManager.Ammo--;
        Ammo_txt.GetComponent<Text>().text = GameManager.Ammo.ToString();
    }

    public void ScoreCount()
    {
        GameManager.Score += 10;
        GameManager.Targets--;
        Score_txt.GetComponent<Text>().text = "Score: " + GameManager.Score.ToString();
    }
}
