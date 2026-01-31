using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
   public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Pause:
                Object.Instantiate(Resources.Load("Transparent"));
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
            case MenuName.Option:
                Object.Instantiate(Resources.Load("Darkness"));
                Object.Instantiate(Resources.Load("OptionMenu"));
                break;
            case MenuName.OptionGameplay:
                Object.Instantiate(Resources.Load("OptionMenu"));
                break;
            case MenuName.Question:
                Object.Instantiate(Resources.Load("QuestionMenu"));
                break;
            case MenuName.Score:
                Object.Instantiate(Resources.Load("ScoreMenu"));
                break;
        }
    }
}
