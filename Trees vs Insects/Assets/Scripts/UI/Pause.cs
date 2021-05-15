using Assets.Scripts.Utility;
using Bogadanul.Assets.Scripts.Utility;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    private SceneChange sceneChange;

    public bool IsPaused
    {
        get => isPaused;
        set
        {
            isPaused = value;
            SetTime();
        }
    }

    public void ToPause(string name)
    {
        if (!IsPaused)
        {
            sceneChange.LoadSceneAd(name);
            IsPaused = true;
        }
    }

    public void ToUnpause(string name)
    {
        if (IsPaused)
        {
            sceneChange.UnloadScene(name);
            IsPaused = false;
        }
    }

    private void SetTime()
    {
        if (IsPaused)
            TimeController.SetTime(0);
        else
            TimeController.SetTime(1);
    }

    private void Start()
    {
        sceneChange = GetComponent<SceneChange>();
    }
}