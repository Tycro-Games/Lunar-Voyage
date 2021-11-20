using Bogadanul.Assets.Scripts.Enemies;
using Bogadanul.Assets.Scripts.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class SliderEnemyHealth : SliderBase
    {
        private EnemyHealth enemyHealth = null;

        private void OnDisable()
        {
            enemyHealth.OnDamage -= UpdateSlider;
        }

        private void Awake()
        {
            slider = GetComponent<Slider>();

            enemyHealth = GetComponentInParent<EnemyHealth>();

            MaximumWeight = enemyHealth.Health;
            enemyHealth.OnDamage += UpdateSlider;
        }
    }
}