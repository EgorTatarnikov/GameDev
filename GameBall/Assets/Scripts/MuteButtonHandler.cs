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

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GameObject.FindWithTag("GameAudioSource").GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (Mute.IsOn)
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
        print("muteIsOn: " + Mute.IsOn);
        Mute.Change();
        if (PlayerPrefs.GetInt("muteIsOn") == 1)
        {
            image.sprite = muteButtonOn;
            audioSource.volume = 0f;
        }
        else
        {
            image.sprite = muteButtonOff;
            audioSource.volume = 1f;
        }
        print("muteIsOn: " + Mute.IsOn);
    }
}