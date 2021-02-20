using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevugLowFramerate : MonoBehaviour
{
    // Start is called before the first frame update
    public void To10 (int fr)
    {
        Application.targetFrameRate = fr;
    }

    public void ToInfinite ()
    {
        Application.targetFrameRate = -1;
    }
}