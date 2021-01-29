using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int Ammo = 7;
    public static int Targets = 5;
    public static int Score = 0;

    public static void TryAgain()
    {
        Ammo = 7;
        Targets = 5;
        Score = 0;
    }
}
