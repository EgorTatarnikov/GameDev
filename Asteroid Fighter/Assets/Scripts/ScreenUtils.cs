using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenUtils
{
    #region Fields

    static int screenWidth;
    static int screenHeight;

    static float screenLeft;
    static float screenRight;
    static float screenTop;
    static float screenBottom;
    static float screenCoefficient = 1.0f;     // for screen resolution 2400/1080
    static float screenCoefficientSqrt;

    #endregion

    #region Properties

    public static float ScreenLeft
    {
        get
        {
            CheckScreenSizeChanged();
            return screenLeft;
        }
    }

    public static float ScreenRight
    {
        get
        {
            CheckScreenSizeChanged();
            return screenRight;
        }
    }

    public static float ScreenTop
    {
        get
        {
            CheckScreenSizeChanged();
            return screenTop;
        }
    }

    public static float ScreenBottom
    {
        get 
        {
            CheckScreenSizeChanged();
            return screenBottom; 
        }
    }

    public static float ScreenCoefficient
    {
        get { return screenCoefficient; }
    }

    public static float ScreenCoefficientSqrt
    {
        get { return screenCoefficientSqrt; }
    }

    #endregion

    #region Methods
    public static void Initialize()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = new Vector3(screenWidth, screenHeight, screenZ);
        Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld = Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
        screenLeft = lowerLeftCornerWorld.x;
        screenRight = upperRightCornerWorld.x;
        screenTop = upperRightCornerWorld.y;
        screenBottom = lowerLeftCornerWorld.y;

        screenCoefficient = (1080.0f / 2400.0f) * Screen.height / Screen.width;
        screenCoefficientSqrt = Mathf.Sqrt(screenCoefficient);
    }

    static void CheckScreenSizeChanged()
    {
        if (screenWidth != Screen.width ||
            screenHeight != Screen.height)
        {
            Initialize();
        }
    }
    #endregion
}
