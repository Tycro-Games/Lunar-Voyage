using Bogadanul.Assets.Scripts.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private static bool isPaused = false;
    private SceneChange sceneChange;

    public bool IsPaused
    {
        get => isPaused;
        set
        {
            isPaused = value;
            SetTime ();
        }
    }

    public void ToPause (string name)
    {
        if (!isPaused)
        {
            sceneChange.LoadSceneAd (name);
            isPaused = true;
        }
    }

    public void ToUnpause (string name)
    {
        if (isPaused)
        {
            sceneChange.UnloadScene (name);
            isPaused = false;
        }
    }

    private void SetTime ()
    {
        if (isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    private void Start ()
    {
        sceneChange = GetComponent<SceneChange> ();
    }
}