using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;
using System.IO;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Image image;
    [SerializeField]
    Sprite muteButtonOn;
    [SerializeField]
    Sprite muteButtonOff;

    private void Start()
    {
        AudioManager.Play(AudioClipName.MainMenuTheme);
        if (PlayerPrefs.GetInt("muteIsOn") == 1)
        {
            image.sprite = muteButtonOn;
        }
        else
        {
            image.sprite = muteButtonOff;
        }
    }

    public void HandlePlayButtonOnClickEvent()
    {
        SceneManager.LoadScene("0InfiniteLevel");
        AudioManager.Play(AudioClipName.InfiniteLevelTheme);
    }

    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }

    private void FixedUpdate()
    {
            if (PlayerPrefs.GetInt("muteIsOn") == 1)
            {
                image.sprite = muteButtonOn;
            }
            else
            {
                image.sprite = muteButtonOff;
            }
    }
}
