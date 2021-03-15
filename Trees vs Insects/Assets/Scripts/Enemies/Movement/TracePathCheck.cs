using Bogadanul.Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class TracePathCheck : MonoBehaviour
    {
        protected List<Node> path = null;

        public virtual List<Node> Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }

        private void OnDrawGizmosSelected ()
        {
            if (path != null)
            {
                foreach (Node n in path)
                {
                    Gizmos.color = Color.black;
                    Gizmos.DrawWireCube (n.worldPosition, Vector3.one);
                }
            }
        }
    }
}