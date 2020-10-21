using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void LevelSelect(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void Options()
    {
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }
    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}