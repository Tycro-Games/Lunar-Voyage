using Bogadanul.Assets.Scripts.Grid;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class TracePathCheck : MonoBehaviour
    {
        protected List<Node> path = new List<Node> ();

        public virtual List<Node> SetPath
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
                    Gizmos.DrawCube (n.worldPosition, Vector3.one * 2);
                }
            }
        }
    }
}