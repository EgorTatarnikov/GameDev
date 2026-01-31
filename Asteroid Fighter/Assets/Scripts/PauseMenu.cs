using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    CurrentScoreText currentScoreText;
    GameManagerScript GMScript;
    private void Start()
    {
        Time.timeScale = 0;

        currentScoreText = GameObject.FindWithTag("GuiUpZone").GetComponent<CurrentScoreText>();

        GMScript = GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>();
    }

    public void HandleOptionButtonOnClickEvent()
    {
        MenuManager.GoToMenu(MenuName.OptionGameplay);
    }

    public void HandlHomeButtonOnClickEvent()
    {
        HandleResumeButtonOnClickEvent();

        GameObject[] transparentScoreMenus = GameObject.FindGameObjectsWithTag("TransparentScoreMenu");
        foreach (GameObject transparentScoreMenu in transparentScoreMenus)
        {
            Destroy(transparentScoreMenu);
        }

        GMScript.CurrentScore = 0;
        currentScoreText.GameOverOff();
        Destroy(GameObject.FindWithTag("ScoreMenu"));
        GameObject.FindWithTag("GameManager").GetComponent<MainMenu>().SlideDownInitator = true;
    }

    public void HandleResumeButtonOnClickEvent()
    {
        Destroy(GameObject.FindWithTag("Transparent"));
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}