using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

namespace UI
{
    public class ScreenRes : MonoBehaviour
    {
        [SerializeField]
        private TMP_Dropdown resolutionsOptions = null;

        private Resolution[] resolutions;

        [SerializeField]
        private Toggle fullScreenOn = null;

        public void ResChange(int resIndex)
        {
            Resolution resolution = resolutions[resIndex];

            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            PlayerPrefs.SetInt("Resolution", resIndex);
            PlayerPrefs.Save();
        }

        public void SetFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
            PlayerPrefs.SetInt("Screen", isFullscreen ? 1 : 0);
            PlayerPrefs.Save();
        }

        private void Start()
        {
            resolutions = Screen.resolutions.Select(resolution => new Resolution
            {
                width = resolution.width,
                height = resolution.height
            }).Distinct().ToArray();

            //res
            int res = PlayerPrefs.GetInt("Resolution", 5);
            Resolution resolution = resolutions[res];
            resolutionsOptions.value = res;
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            //fullscreen
            bool isScreenOn = Convert.ToBoolean(PlayerPrefs.GetInt("Screen", 1));
            Screen.fullScreen = isScreenOn;
            fullScreenOn.isOn = isScreenOn;
        }
    }
}