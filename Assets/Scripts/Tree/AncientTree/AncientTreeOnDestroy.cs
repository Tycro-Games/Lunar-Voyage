using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class AncientTreeOnDestroy : MonoBehaviour
    {
        [SerializeField]
        private float hp = 2;

        [SerializeField]
        private UnityEvent OnDead = null;

        [SerializeField]
        private UnityEvent OnDamage = null;

        public void TakeDG(int dg)
        {
            hp -= dg;
            //some effect on enemies explosion
            if (hp <= 0)
            {
                Dead();
            }
            else
                DamageEvent();
        }

        public void DamageEvent()
        {
            OnDamage?.Invoke();
        }

        public void Dead()
        {
            OnDead?.Invoke();
            Debug.Log("Lost");
            //scene manager pops up
        }
    }
}