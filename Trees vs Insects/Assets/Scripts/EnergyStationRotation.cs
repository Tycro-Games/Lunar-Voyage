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
        [SerializeField]
        private SpriteRenderer[] sprite;
        private void Start()
        {

            rotate = GetComponent<Rotate>();
            anim = GetComponent<AnimateDamage>();
            anim.OnCurrentValue.AddListener(rotate.ChangeSpeed);
            
            anim.OnCurrentValue.AddListener(AnimateMore);
        }
        private void AnimateMore(float value)
        {
            
            foreach (SpriteRenderer s in sprite)
            {
                anim.ChangeMaterial(value, s);
            }
        }
        private void OnDisable()
        {
            anim.OnCurrentValue.RemoveListener(rotate.ChangeSpeed);
            anim.OnCurrentValue.RemoveListener(AnimateMore);
        }
    }
}
