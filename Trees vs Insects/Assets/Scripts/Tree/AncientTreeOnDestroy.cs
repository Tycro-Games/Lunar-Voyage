﻿using System;
using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class AncientTreeOnDestroy : MonoBehaviour
    {
        [SerializeField]
        private int health = 2;

        [SerializeField]
        private UnityEvent OnDead = null;

        public void OnTreeReach (int healthlost)
        {
            health -= healthlost;
            //some effect on enemies explosion
            if (health <= 0)
            {
                Dead ();
            }
        }

        public void Dead ()
        {
            OnDead?.Invoke ();
            Debug.Log ("Lost");
            //scene manager pops up
        }
    }
}