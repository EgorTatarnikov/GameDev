using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftButtonImageChanger : MonoBehaviour
{
    [SerializeField]
    Image image;
    [SerializeField]
    Sprite leftOn;
    [SerializeField]
    Sprite leftOff;

    void Start()
    {
        image.sprite = leftOff;
    }

    public void LeftButtonEnterEvent(bool isEntered)
    {
        if (isEntered)
        {
            image.sprite = leftOn;
        }
        if (!isEntered)
        {
            image.sprite = leftOff;
        }
    }
}
