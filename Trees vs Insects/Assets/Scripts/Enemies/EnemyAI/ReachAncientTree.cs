using Bogadanul.Assets.Scripts.Tree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class ReachAncientTree : MonoBehaviour
    {
        [SerializeField]
        private int ancientTreeHealthLost = 1;

        [SerializeField]
        private LayerMask layerMask = 0;

        public int AncientTreeHealthLost { get => ancientTreeHealthLost; set => ancientTreeHealthLost = value; }

        public void Reached ()

        {
            
            Destroy (gameObject);
        }
    }
}