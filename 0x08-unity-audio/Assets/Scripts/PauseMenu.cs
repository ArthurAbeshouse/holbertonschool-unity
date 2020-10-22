using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;
    public GameObject PauseCanvas;
    public GameObject Main_cam;

    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;

    private void Start()
    {
        unpaused.TransitionTo(.01f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            } 
        }
    }

    public void Pause()
    {
        PauseCanvas.SetActive(true);
        Main_cam.GetComponent<CameraController>().enabled = false;
        Time.timeScale = 0;
        Lowpass();
    }

    public void Resume()
    {
        PauseCanvas.SetActive(false);
        Main_cam.GetComponent<CameraController>().enabled = true;
        Time.timeScale = 1;
        Lowpass();
    }

    void Lowpass()
    {
        if (Time.timeScale == 0)
        {
            paused.TransitionTo(.01f);
        }
        else
        {
            unpaused.TransitionTo(.01f);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Options()
    {
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
        Time.timeScale = 1;
    }
}
