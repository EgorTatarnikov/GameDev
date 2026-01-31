using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute
{
    static int mInt;
    static bool muteIsOn;

    public static bool IsOn
    {
        get { return muteIsOn; }
    }

    public static void LoadMutePrefs()
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

    public static void SetMutePrefs()
    {
        if (muteIsOn == true)
        {
            mInt = 1;
        }
        if (muteIsOn == false)
        {
            mInt = 0;
        }
        PlayerPrefs.SetInt("muteIsOn", mInt);
    }

    public static void Change()
    {
        LoadMutePrefs();
        muteIsOn = !muteIsOn;
        SetMutePrefs();
    }
}
