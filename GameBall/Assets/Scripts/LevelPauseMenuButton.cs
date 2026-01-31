using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPauseMenuButton : MonoBehaviour
{
    public void HandleMenuButtonOnClickEvent()
    {
        GameObject PauseMenu = GameObject.FindWithTag("PauseMenu");
        if (PauseMenu == null)
        {
            MenuManager.GoToMenu(MenuName.Pause);
            GiftKeeper.SafeGiftListAndScore();
        }
        else
        {
            Time.timeScale = 1;
            Destroy(PauseMenu);
        }
    }
}
