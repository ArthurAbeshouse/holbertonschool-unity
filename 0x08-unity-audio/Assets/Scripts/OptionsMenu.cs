using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invert_cam;

    public static int invert = 1;

    // Start is called before the first frame update
    private void Start()
    {
        if (PlayerPrefs.HasKey("isInverted"))
        {
            invert_cam.isOn = PlayerPrefs.GetInt("isInverted") == 0 ? false : true;
        }
        else
        {
            invert_cam.isOn = false;
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("LastScene"));
        Time.timeScale = 1;
    }

    public void Apply()
    {
        PlayerPrefs.SetInt("isInverted", invert_cam.isOn ? 1 : 0);
        if (invert_cam.isOn)
        {
            //Debug.Log("invert");
            invert = -1;
        }
        else
        {
            //Debug.Log("regular");
            invert = 1;
        }
    }
}
