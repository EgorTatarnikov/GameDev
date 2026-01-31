using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAppPause : MonoBehaviour
{
    bool isPaused = false;

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;

        if (isPaused && GameObject.FindWithTag("PauseMenu") == null)
        {
            if (GetComponent<Level1>() != null || 
                GetComponent<Level2>() != null || 
                GetComponent<Level3>() != null ||
                GetComponent<Level4>() != null)
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }
}
