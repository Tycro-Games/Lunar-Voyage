using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class TimeController : MonoBehaviour
    {
        public void ChangeTime(float number)
        {
            Time.timeScale += number;
        }
    }
}