using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul
{
    public class EndLevel : MonoBehaviour
    {
        public static event Action EndGame;

        [SerializeField]
        private float time = 2.0f;

        private IEnumerator OnMouseDown()
        {
            yield return new WaitForSecondsRealtime(time);
            EndGame?.Invoke();
        }
    }
}