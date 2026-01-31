using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0;
    }

    public void HandleResumeButtonOnClickEvent()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void HandlHomeButtonOnClickEvent()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

}

