using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightButtonImageChanger : MonoBehaviour
{
    [SerializeField]
    Image image;
    [SerializeField]
    Sprite rightOn;
    [SerializeField]
    Sprite rightOff;

    void Start()
    {
        image.sprite = rightOff;
    }

    public void RightButtonEnterEvent(bool isEntered)
    {
        if (isEntered)
        {
            image.sprite = rightOn;
        }
        if (!isEntered)
        {
            image.sprite = rightOff;
        }
    }
}
