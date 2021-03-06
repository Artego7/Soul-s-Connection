﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    public GameObject mainMenu;
    public GameObject optionMenu;

        //PauseMenu pauseMenu;

        //void Awake()
        //{
        //    if (PlayerPrefs.GetInt("optionIsSelected", 1))
        //    {
        //        mainMenu.SetActive(false);
        //        optionMenu.SetActive(true);
        //    }
        //    else
        //    {
        //        mainMenu.SetActive(false);
        //        optionMenu.SetActive(true);
        //    }
        //    if (pauseMenu.optionsIsSelected == 1)
        //    {
        //        mainMenu.SetActive(false);
        //        optionMenu.SetActive(true);
        //    }
        //    else
        //    {
        //        mainMenu.SetActive(false);
        //        optionMenu.SetActive(true);
        //    }
        //}



    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width.ToString() + " x " + resolutions[i].height.ToString() + "  @" + resolutions[i].refreshRate.ToString() + " Hz";
            options.Add(option);
            //He compares resolution[i] with Screen.currentResolution but that´s wrong. 
            //CurrentResolution gives the Resolution of the monitor but we want to compare it with the Resolution of the window in case we change the scene. 
            //That´s why we have to compare resolution[i].width with Screen.width and  resolution[i].height with Screen.height.﻿
            if (resolutions[i].width == Screen.width
                && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("mainVolume", volume);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
   
        Screen.SetResolution(Screen.width, Screen.height, isFullScreen);

    }

}
