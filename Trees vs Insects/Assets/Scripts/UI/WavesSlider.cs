using Bogadanul.Assets.Scripts.Enemies;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Bogadanul.Assets.Scripts.UI
{
    public class WavesSlider : MonoBehaviour
    {
        private int TotalWeight = 0;
        private float currentWeight = 0;
        private Slider slider = null;
        private WaveSystem waveSystem = null;
        private IEnumerator currentChange;
       private float desiredWeight;
       [SerializeField]
        private AnimationCurve curve;
        [SerializeField]
        private float baseSpeed = 1.0f;
        public void UpdateSlider(int weight)
        {
            if (currentChange != null&& currentChange.Current!=null)
            {
                desiredWeight += weight;
                
            }
            else
            {
                currentChange = UpdateOnTime(weight);
                StartCoroutine(currentChange);
            }
        }

        private IEnumerator UpdateOnTime(int weight)
        {

            float time = 0f;
             desiredWeight = currentWeight + weight;
            while (currentWeight <= desiredWeight)
            {
                time += Time.deltaTime;

                float linearT = time / weight;
                float heightT = curve.Evaluate(linearT)* baseSpeed;
                currentWeight += heightT;
                slider.value = Mathf.InverseLerp (0, TotalWeight, currentWeight);
                yield return null;
            }
            Debug.Log("finish");
          
        }

        private void OnDisable()
        {
            waveSystem.OnSpawn -= UpdateSlider;
        }

        private void Awake()
        {
            slider = GetComponent<Slider>();

            waveSystem = FindObjectOfType<WaveSystem>();
            foreach (Wave wave in waveSystem.waves)
            {
                TotalWeight += wave.weight;
            }
            waveSystem.OnSpawn += UpdateSlider;
        }
    }
}