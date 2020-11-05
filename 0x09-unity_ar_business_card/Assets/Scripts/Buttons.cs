using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void buttonFunction(string btnLink)
    {
        Application.OpenURL(btnLink);
    }
}
