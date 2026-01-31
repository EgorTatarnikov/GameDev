using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandleFireButtonOnTouchEvent : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBullet;
    [SerializeField]
    GameObject spaceship;
    Vector3 spaceshipPosition;
    Vector3 spavnPosition;

    [SerializeField]
    Image image;
    [SerializeField]
    Sprite fireOn;
    [SerializeField]
    Sprite fireOff;

    Timer timer;
    bool isAble = false;
    int charges = 0;

    float Xcoordinate;

    private void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 0.2f;
        image.sprite = fireOff;
        timer.Run();
    }

    private void Update()
    {
        if (timer.Finished && (isAble || charges>0))
        {
            AutoFire();
            charges--;
            if (!isAble) 
            {
                charges = 0;
            }
        }
    }

    public void FireButtonOnEnterEvent(bool isEntered)
    {
        if (isEntered)
        {
            charges++;
            image.sprite = fireOn;
            isAble = true;
        }
        if (!isEntered)
        {
            image.sprite = fireOff;
            isAble = false;
        }
    }

    void AutoFire()
    {
        spaceshipPosition = spaceship.transform.position;

        Xcoordinate = spaceshipPosition.x;
        if (Xcoordinate > 1.875)
        {
            Xcoordinate = 1.875f;
        }
        if (Xcoordinate < -1.875)
        {
            Xcoordinate = -1.875f;
        }
        spavnPosition = new Vector3(Xcoordinate, spaceshipPosition.y + 0.6f, spaceshipPosition.z);

        Instantiate(prefabBullet, spavnPosition, Quaternion.identity);
        timer.Run();
    }
}
