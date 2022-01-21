using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IfOnAndroid : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnStart;
    private void Start()
    {
#if UNITY_ANDROID
        if (Application.internetReachability == NetworkReachability.NotReachable)
            return;
        OnStart?.Invoke();
        Destroy(this);
#endif
    }
}
