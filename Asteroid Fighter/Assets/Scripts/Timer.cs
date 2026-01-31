using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region Fields
    public float totalSeconds = 0;
    float elapsedSeconds = 0;
    bool running = false;
    bool started = false;
    #endregion

    #region Properties
    public float Duration
    {
        set
        {
            if (!running)
            {
                totalSeconds = value;
            }
        }
    }

    public bool Finished
    {
        get { return started && !running; }
    }

    public bool Running
    {
        get { return running; }
    }

    public float CurrentTime
    {
        get { return elapsedSeconds; }
    }
    #endregion

    #region Methods
    void Update()
    {
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= totalSeconds)
            {
                running = false;
                elapsedSeconds = 0;
            }
        }
    }

    public void Run()
    {
        if (totalSeconds > 0)
        {
            started = true;
            running = true;
        }
    }

    public void Stop()
    {
        running = false;
        started = false;
        elapsedSeconds = 0;
    }
    #endregion
}