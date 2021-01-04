using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bogadanul.Assets.Scripts.Player
{
    public class Cooldown : MonoBehaviour
    {
        public bool IsDone = true;
        private float CountDown = 10;

        private float currentT = 0;

        [SerializeField]
        private Image coolDownEf = null;

        [SerializeField]
        private Button button = null;

        public void Init (float count)
        {
            CountDown = count;
        }

        public void ResetT ()
        {
            currentT = CountDown;
            button.interactable = false;
        }

        private void Update ()
        {
            TimeDrain ();
        }

        private void TimeDrain ()
        {
            if (currentT > 0)
            {
                currentT -= Time.deltaTime;
                coolDownEf.fillAmount = Mathf.InverseLerp (0, CountDown, currentT);
            }
            else
                IsDone = true;
        }
    }
}