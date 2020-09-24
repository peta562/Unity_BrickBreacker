using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource soundSource;
    public AudioSource musicSource;

    public AudioClip music;

    void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (instance == null)
        {
            instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        PlayMusic(music, 0.2f);
    }


    public void PlaySound(AudioClip soundClip, float soundVolume)
    {
        soundSource.volume = soundVolume;
        soundSource.clip = soundClip;
        if (!soundSource.isPlaying)
        {
            soundSource.Play();
        }
    }

    public void PlayMusic(AudioClip musicClip, float soundVolume)
    {
        musicSource.volume = soundVolume;
        musicSource.clip = musicClip;
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }
}
