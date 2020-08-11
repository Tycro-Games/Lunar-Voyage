
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float TimeToWait = 0;

    [SerializeField]
    private bool loop = false;

    [SerializeField]
    private UnityEvent OnTimerFinished = null;

    

    private void OnEnable ()
    {
        StartCoroutine (TimerLoop ());
    }
    private void OnDisable ()
    {
        StopCoroutine (TimerLoop ());
    }
    IEnumerator TimerLoop ()
    {
        yield return new WaitForSeconds (TimeToWait);
        OnTimerFinished?.Invoke ();

        if (loop)
            StartCoroutine (TimerLoop());
    }

}