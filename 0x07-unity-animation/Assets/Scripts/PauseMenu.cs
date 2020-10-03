using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;
    public GameObject PauseCanvas;
    public GameObject Main_cam;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            isPaused = !isPaused;
        }
    }

    public void Pause()
    {
        PauseCanvas.SetActive(true);
        Main_cam.GetComponent<CameraController>().enabled = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        PauseCanvas.SetActive(false);
        Main_cam.GetComponent<CameraController>().enabled = true;
        Time.timeScale = 1;
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
