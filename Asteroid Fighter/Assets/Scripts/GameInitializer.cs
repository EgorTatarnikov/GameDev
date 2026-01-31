using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour 
{
    bool muteIsOn = false;
    bool vibrationIsOn = true;
    int vInt = 2;
    int mInt = 2;

    public bool MuteIsOn
    {
        get { return muteIsOn; }
    }
    public bool VibrationIsOn
    {
        get { return vibrationIsOn; }
    }

    void Awake()
    {
        ScreenUtils.Initialize();
        LoadMutePrefs();
        LoadVibrationPrefs();

        GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>().RecordScore = PlayerPrefs.GetInt("recordScore");
        AudioSource audioSource = GetComponent<AudioSource>();
        AudioManager.Initialize(audioSource);
        
        if (PlayerPrefs.GetInt("muteIsOn") == 1)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().volume = 0f;
        }
        else
        {
            GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().volume = 1f;
        }
    }

    void LoadMutePrefs()
    {
        mInt = PlayerPrefs.GetInt("muteIsOn");
        if (mInt == 1)
        {
            muteIsOn = true;
        }
        if (mInt == 0)
        {
            muteIsOn = false;
        }
    }

    void LoadVibrationPrefs()
    {
        vInt = PlayerPrefs.GetInt("vibrationIsOn");
        if (vInt == 0)
        {
            vibrationIsOn = true;
        }
        if (vInt == 1)
        {
            vibrationIsOn = false;
        }
    }
}