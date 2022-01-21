using Assets.Scripts.Utility;
using Bogadanul.Assets.Scripts.Utility;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    private SceneChange sceneChange;
    private bool isLoading = false;

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
        if (!IsPaused && isLoading == false)
        {
            sceneChange.LoadSceneAd(name);
            IsPaused = true;
        }
    }

    public void ToPause()
    {
        IsPaused = true;
    }

    public void ToUnpause()
    {
        IsPaused = false;
    }

    public void ToUnpause(int hp)
    {
        if (IsPaused)
            IsPaused = false;
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

    private void Isloading()
    {
        isLoading = true;
    }

    private void OnEnable()
    {
        EndLevel.BeforeCoolDown += Isloading;
    }

    private void OnDisable()
    {
        EndLevel.BeforeCoolDown -= Isloading;
    }

    private void Start()
    {
        isLoading = false;
        sceneChange = GetComponent<SceneChange>();
    }
}