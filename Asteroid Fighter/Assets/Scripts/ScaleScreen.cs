using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScreen : MonoBehaviour
{
    void Awake()
    {
        ScreenUtils.Initialize();
        GetComponent<Camera>().orthographicSize = 5 * ScreenUtils.ScreenCoefficient;
        ScreenUtils.Initialize();
    }
}
