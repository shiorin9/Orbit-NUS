﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    public void StartSelect(Object scene)
    {
        FindObjectOfType<AudioManager>().Play("Button");
        FindObjectOfType<AudioManager>().StopPlaying("Menu");
        FindObjectOfType<SettingsMenu>().NextTrack();
        SceneLoad.prevScene = null;
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
    }
}
