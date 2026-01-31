using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSMeter : MonoBehaviour
{
    Text text;
    float averigeFPS;
    float[] fpsArray = new float[60];
    int frameIndex = 0;

    public float AverigeFPS
    {
        get 
        { 
            return Mathf.RoundToInt(CalculateAverigeFPS()); 
        }
    }


    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        fpsArray[frameIndex] = 1 / Time.deltaTime;
        frameIndex++;
        if (frameIndex >= fpsArray.Length)
        {
            frameIndex = 0;
        }
        text.text = "FPS: " + AverigeFPS;
    }

    float CalculateAverigeFPS()
    {
        float sum = 0;
        foreach (var fps in fpsArray)
        {
            sum += fps;
        }
        averigeFPS = sum / fpsArray.Length;
        return averigeFPS;
    }
}
