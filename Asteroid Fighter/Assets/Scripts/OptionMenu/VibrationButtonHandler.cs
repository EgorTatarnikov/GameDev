using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrationButtonHandler : MonoBehaviour
{
    [SerializeField]
    Image image;
    [SerializeField]
    Sprite vibrationButtonOn;
    [SerializeField]
    Sprite vibrationButtonOff;

    int vInt;
    bool vibrationIsOn;

    private void Start()
    {
        LoadVibrationPrefs();
        if (vibrationIsOn)
        {
            image.sprite = vibrationButtonOn;
        }
        else
        {
            image.sprite = vibrationButtonOff;
        }
    }

    public void VibrationButtonPointerDownEvent()
    {
        vibrationIsOn = !vibrationIsOn;
        if (vibrationIsOn)
        {
            image.sprite = vibrationButtonOn;
            Handheld.Vibrate();
        }
        else
        {
            image.sprite = vibrationButtonOff;
        }
        SetVibrationPrefs();
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

    void SetVibrationPrefs()
    {
        if (vibrationIsOn == true)
        {
            vInt = 0;
        }
        if (vibrationIsOn == false)
        {
            vInt = 1;
        }
        PlayerPrefs.SetInt("vibrationIsOn", vInt);
    }
}