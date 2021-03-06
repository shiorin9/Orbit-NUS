﻿using UnityEngine.Audio;
using UnityEngine;
using System;
//using Packages.Rider.Editor;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private string CurrScene;

    public Sound[] sounds;

    public static AudioManager instance;

    public static int LastBGM;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        CurrScene = SceneManager.GetActiveScene().name;
        if (CurrScene == "Main Menu")
            Play("Menu");
    }

    public void Play(string name)
    {
        if(SettingsMenu.DiscoMode)
        {
            name = "Disco" + name;
        }
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        if (SettingsMenu.IsMuted == false)
        {
            s.source.Play();
        }
    }

    public void StopPlaying(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + sound + " not found!");
            return;
        }
        s.source.Stop();
    }

    public void StopLast()
    {
        if (SettingsMenu.DiscoMode)
        {
            StopPlaying("DiscoBGM" + LastBGM);
        }
        else
        {
            StopPlaying("BGM" + LastBGM);
        }
    }

    public void StopAll()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }
}
