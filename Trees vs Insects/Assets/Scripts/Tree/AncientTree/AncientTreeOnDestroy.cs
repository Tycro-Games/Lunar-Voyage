using System;
using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class AncientTreeOnDestroy : DestroyTree
    {
       

        [SerializeField]
        private UnityEvent OnDead = null;

        [SerializeField]
        private UnityEvent OnDamage = null;

        public override void TakeDG (int dg)
        {
         
            hp -= dg;
            //some effect on enemies explosion
            if (hp <= 0)
            {
                Dead ();
            }
            else
                OnDamage?.Invoke ();
        }
         
        

        public void Dead ()
        {
            OnDead?.Invoke ();
            Debug.Log ("Lost");
            //scene manager pops up
        }
    }
}