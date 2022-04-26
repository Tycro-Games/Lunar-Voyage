using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Bogadanul.Assets.Scripts.UI
{
    public class SliderBase : MonoBehaviour
    {
        protected int MaximumWeight = 0;
        protected float currentWeight = 0;
        protected Slider slider = null;
        protected IEnumerator currentChange;
        protected float desiredWeight = 0;

        [SerializeField]
        protected AnimationCurve curve;

        [SerializeField]
        protected float baseSpeed = 1.0f;
        bool isLoading = false;
        public void UpdateSlider(int weight)
        {
            desiredWeight += weight;
            if(!isLoading)
            StartCoroutine(UpdateOnTime(weight));
        }

        private IEnumerator UpdateOnTime(int weight)
        {
            float time = 0f;
            isLoading = true;
            while (currentWeight <= desiredWeight)
            {
                time += Time.deltaTime;
                float linearT = time / weight;
                float heightT = curve.Evaluate(linearT) * baseSpeed;
                currentWeight += heightT;
                slider.value = Mathf.InverseLerp(0, MaximumWeight, currentWeight);
                yield return null;
            }
            currentWeight = desiredWeight;
            isLoading = false;
        }
    }
}