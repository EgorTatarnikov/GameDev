using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMenu : MonoBehaviour
{
    public void HandleResumeButtonOnClickEvent()
    {
        Destroy(gameObject);
    }

    public void HandleLifesButtonOnClickEvent()
    {
        GameObject.FindWithTag("Spaceship").GetComponent<Spaceship>().Lifes = 1000;
    }

    public void HandleScoreButtonOnClickEvent()
    {
        PlayerPrefs.SetInt("recordScore", 0);
    }

    public void OpenMySiteOnGooglePlay()
    {
        Application.OpenURL("https://www.rustore.ru/catalog/developer/3owdtx"); 
    }
}
