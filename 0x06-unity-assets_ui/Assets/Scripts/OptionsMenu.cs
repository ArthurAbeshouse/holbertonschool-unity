using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invert_cam;

    // Start is called before the first frame update
    public void Back()
    {
        SceneManager.LoadScene("PreviousScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
