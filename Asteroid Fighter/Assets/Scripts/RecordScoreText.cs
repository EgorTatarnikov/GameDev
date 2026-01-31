using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordScoreText : MonoBehaviour
{
    TextPrinter TPrinter;
    GameManagerScript GMScript;

    void Start()
    {
        TPrinter = GameObject.FindWithTag("ScoreRomb").GetComponent<TextPrinter>();
        GMScript = GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>();
        TPrinter.PrintScore(GMScript.RecordScore);
    }

    public void PrintRecordScore()
    {
        TPrinter.PrintScore(GMScript.RecordScore);
    }
}
