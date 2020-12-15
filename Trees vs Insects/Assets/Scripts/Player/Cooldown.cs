using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bogadanul.Assets.Scripts.Player
{
    public class Cooldown : MonoBehaviour
    {
        private float CountDown = 10;

        private float currentT = 0;

        [SerializeField]
        private Image coolDownEf;

        [SerializeField]
        private Button button;

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
                button.interactable = true;
        }
    }
}