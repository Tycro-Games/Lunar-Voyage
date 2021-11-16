using Assets.Scripts.Enemies.EnemyAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul
{
    public class EnergyStationRotation : MonoBehaviour
    {
        private Rotate rotate;
        private AnimateDamage anim;
        private void Start()
        {
            rotate = GetComponent<Rotate>();
            anim = GetComponent<AnimateDamage>();
            anim.OnCurrentValue.AddListener(rotate.ChangeSpeed);
        }
        private void OnDisable()
        {
            anim.OnCurrentValue.RemoveListener(rotate.ChangeSpeed);
        }
    }
}
