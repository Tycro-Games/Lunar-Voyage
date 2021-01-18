using Bogadanul.Assets.Scripts.Enemies;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Bogadanul.Assets.Scripts.UI
{
    public class WavesSlider : MonoBehaviour
    {
        private int TotalWeight = 0;
        private int currentWeight = 0;
        private Slider slider = null;
        private WaveSystem waveSystem = null;

        public void UpdateSlider (int weight)
        {
            currentWeight += weight;
            slider.value = Mathf.InverseLerp (0, TotalWeight, currentWeight);
        }

        private void OnDisable ()
        {
            waveSystem.OnSpawn -= UpdateSlider;
        }

        private void Awake ()
        {
            slider = GetComponent<Slider> ();

            waveSystem = FindObjectOfType<WaveSystem> ();
            foreach (Wave wave in waveSystem.waves)
            {
                TotalWeight += wave.weight;
            }
            waveSystem.OnSpawn += UpdateSlider;
        }
    }
}