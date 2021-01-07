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

        private Market market = null;
        private TreeSeedContainer treeSeed = null;

        public void Init (float count)
        {
            CountDown = count;
        }

        public void ResetT ()
        {
            currentT = CountDown;
            IsDone = false;
        }

        public void Onvalue (int current)
        {
            if (!IsDone || treeSeed.treeSeed.price > current)
                button.interactable = false;
            else
            {
                button.interactable = true;
            }
        }

        private void Update ()
        {
            TimeDrain ();
        }

        private void Start ()
        {
            treeSeed = GetComponent<TreeSeedContainer> ();
            market = FindObjectOfType<Market> ();

            market.marketIntro.OnEnergyChange += Onvalue;
            IsDone = true;
        }

        private void OnDisable ()
        {
            market.marketIntro.OnEnergyChange -= Onvalue;
        }

        private void TimeDrain ()
        {
            if (currentT > 0)
            {
                currentT -= Time.deltaTime;
                coolDownEf.fillAmount = Mathf.InverseLerp (0, CountDown, currentT);
            }
            else
            {
                IsDone = true;
                Onvalue (market.marketIntro.WaterInst);
               
            }
        }
    }
}