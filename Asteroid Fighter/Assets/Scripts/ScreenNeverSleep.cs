using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenNeverSleep : MonoBehaviour
{
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
