using Bogadanul.Assets.Scripts.Enemies;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Bogadanul.Assets.Scripts.UI
{
    public class WavesSlider : SliderBase
    {
        private WaveSystem waveSystem = null;

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
                MaximumWeight += wave.weight;
            }
            waveSystem.OnSpawn += UpdateSlider;
        }
    }
}