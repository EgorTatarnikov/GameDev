using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();


    public static bool Initialized
    {
        get { return initialized; }
    }

    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;

        audioClips.Add(AudioClipName.MainTheme, 
            Resources.Load<AudioClip>("AsteroidFighter04"));
        audioClips.Add(AudioClipName.Blow1,
            Resources.Load<AudioClip>("Blow1"));
        audioClips.Add(AudioClipName.Blow2,
            Resources.Load<AudioClip>("Blow2"));
        audioClips.Add(AudioClipName.Blow3,
            Resources.Load<AudioClip>("Blow3"));
        audioClips.Add(AudioClipName.Blow4,
            Resources.Load<AudioClip>("Blow4"));
        audioClips.Add(AudioClipName.Blow5,
            Resources.Load<AudioClip>("Blow22"));
        audioClips.Add(AudioClipName.Blow6,
            Resources.Load<AudioClip>("Blow32"));
        audioClips.Add(AudioClipName.SpaceshipBlow,
            Resources.Load<AudioClip>("SpaceshipBlow"));
        audioClips.Add(AudioClipName.Shot,
            Resources.Load<AudioClip>("SpaceshipShotQuiet4"));
        audioClips.Add(AudioClipName.LittleBlow,
            Resources.Load<AudioClip>("LittleBlow"));
        audioClips.Add(AudioClipName.Sound,
            Resources.Load<AudioClip>("Sound"));
        audioClips.Add(AudioClipName.Puff,
            Resources.Load<AudioClip>("Blow1"));
        audioClips.Add(AudioClipName.Wooow,
            Resources.Load<AudioClip>("Wooow06"));
        audioClips.Add(AudioClipName.Boss3Blow,
            Resources.Load<AudioClip>("Boss3Blow2"));

        if (PlayerPrefs.GetInt("muteIsOn") == 1)
        {
            audioSource.volume = 0f;
        }
        else
        {
            audioSource.volume = 0.4f;
        }
    }

    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }

    public static void PlayRandomBlow()
    {
        int i = Random.Range(1, 5);
        switch (i)
        {
            case 1:
                Play(AudioClipName.Blow1);
                break;
            case 2:
                Play(AudioClipName.Blow4);
                break;
            case 3:
                Play(AudioClipName.Blow5);
                break;
            case 4:
                Play(AudioClipName.Blow6);
                break;
            default:
                Play(AudioClipName.Blow1);
                break;
        }
    }
}
