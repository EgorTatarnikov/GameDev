using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButtonHandler : MonoBehaviour
{
    [SerializeField]
    Image image;
    [SerializeField]
    Sprite muteButtonOn;
    [SerializeField]
    Sprite muteButtonOff;

    int mInt;
    bool muteIsOn;
    AudioSource audioSource;
    GameObject MainCamera;
    AudioSource audioSourceMainCamera;

    private void Awake()
    {
        audioSource = GameObject.FindWithTag("GameManager").GetComponent<AudioSource>();
        MainCamera = GameObject.FindWithTag("MainCamera");
        audioSourceMainCamera = MainCamera.GetComponent<AudioSource>();
    }

    private void Start()
    {
        LoadMutePrefs();
        if (muteIsOn)
        {
            image.sprite = muteButtonOn;
        }
        else
        {
            image.sprite = muteButtonOff;
        }
    }

    public void MuteButtonPointerDownEvent()
    {
        LoadMutePrefs();
        muteIsOn = !muteIsOn;
        if (muteIsOn)
        {
            image.sprite = muteButtonOn;
            audioSource.volume = 0f;
            audioSourceMainCamera.volume = 0f;
        }
        else
        {
            image.sprite = muteButtonOff;
            audioSource.volume = 0.4f;
            audioSourceMainCamera.volume = 1f;
        }
        SetMutePrefs();
    }

    void LoadMutePrefs()
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

    void SetMutePrefs()
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
}