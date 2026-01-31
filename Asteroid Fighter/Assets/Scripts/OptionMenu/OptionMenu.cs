using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    public void HandleQuestionButtonOnClickEvent()
    {
        MenuManager.GoToMenu(MenuName.Question);
    }
    public void HandleResumeButtonOnClickEvent()
    {
        if (GameObject.FindWithTag("Darkness") != null)
        {
            Destroy(GameObject.FindWithTag("Darkness"));
        }
        Destroy(gameObject);
    }
}
