using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScoreText : MonoBehaviour
{
    [SerializeField]
    Image gameOver;

    TextPrinter TPrinter;
    GameManagerScript GMScript;

    void Start()
    {
        TPrinter = GameObject.FindWithTag("GuiUpZone").GetComponent<TextPrinter>();
        GMScript = GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>();
        TPrinter.PrintScore(GMScript.CurrentScore);
        gameOver.color = new Color(1, 1, 1, 0);
    }

    public void PrintCurrentScore()
    {
        TPrinter.PrintScore(GMScript.CurrentScore);
    }

    public void GameOverOn()
    {
        TPrinter.MakeTransparent();
        gameOver.color = new Color(1, 1, 1, 1);
    }
    public void GameOverOff()
    {
        TPrinter.PrintScore(GMScript.CurrentScore);
        gameOver.color = new Color(1, 1, 1, 0);
    }
}
