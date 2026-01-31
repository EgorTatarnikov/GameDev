using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// An audio source for the entire game
/// </summary>
public class GameAudioSource : MonoBehaviour
{

    AudioSource audioSource;
    int mInt;
    bool muteIsOn;

    /// <summary>
    /// Awake is called before Start
    /// </summary>
    void Awake()
	{
        audioSource = gameObject.GetComponent<AudioSource>();
        // make sure we only have one of this game object
        // in the game
        if (!AudioManager.Initialized)
        {
            // initialize audio manager and persist audio source across scenes
            AudioManager.Initialize(audioSource);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // duplicate game object, so destroy
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("muteIsOn") == 1)
        {
            audioSource.volume = 0f;
        }
        else
        {
            audioSource.volume = 1f;
        }
    }
}
