using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    #region Fields
    int backLayerSortingOrger = 0;
    int secondLayerSortingOrger = 0;
    int currentScore;
    int recordScore;
    int lastRecord = 0;

    bool boss1Killed = false;
    bool boss2Killed = false;
    bool boss3Killed = false;
    
    [SerializeField]
    CurrentScoreText currentScoreText;
    [SerializeField]
    RecordScoreText recordScoreText;

    #endregion

    #region Properties
    public int BackLayerSortingOrger
    {
        get { return backLayerSortingOrger; }
    }
    public int SecondLayerSortingOrger
    {
        get { return secondLayerSortingOrger; }
    }

    public int CurrentScore
    {
        get { return currentScore; }
        set { currentScore = value; }
    }

    public int RecordScore
    {
        get { return recordScore; }
        set { recordScore = value; }
    }

    public int LastRecord
    {
        get { return lastRecord; }
        set { lastRecord = value; }
    }

    public bool Boss1Killed
    {
        get { return boss1Killed; }
        set { boss1Killed = value; }
    }

    public bool Boss2Killed
    {
        get { return boss2Killed; }
        set { boss2Killed = value; }
    }

    public bool Boss3Killed
    {
        get { return boss3Killed; }
        set { boss3Killed = value; }
    }
    #endregion

    #region Methods 
    private void Awake()
    {
        ScreenUtils.Initialize();
    }

    void Start()
    {
        EventManager.AddListenerPrintInfiniteEvent(PrintInfiniteGame);       //////////// Adding event listener
    }
    void Update()
    { 

    }

    public void PrintInfiniteGame()                                          //////////// Act event
    {
        print("InfiniteGame");
    }

    public void ChangeBackLayerSortingOrger()
    { 
        if (backLayerSortingOrger == 0)
        {
            backLayerSortingOrger = 1;
        }
        else
        {
            backLayerSortingOrger = 0;
        }
    }
    public void ChangeSecondLayerSortingOrger()
    {
        if (secondLayerSortingOrger == 0)
        {
            secondLayerSortingOrger = 1;
        }
        else
        {
            secondLayerSortingOrger = 0;
        }
    }

    public void AddPoints(int points)
    {
        CurrentScore += points;
        currentScoreText.PrintCurrentScore();
        if (CurrentScore > RecordScore)
        {
            RecordScore = CurrentScore;
            PlayerPrefs.SetInt("recordScore", RecordScore);
            recordScoreText.PrintRecordScore();
        }
    }
    #endregion
}


