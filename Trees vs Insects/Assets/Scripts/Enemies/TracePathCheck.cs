using Bogadanul.Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class TracePathCheck : MonoBehaviour
    {
        protected List<Node> path = new List<Node> ();

        public virtual List<Node> Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
                DisplayPathManager.AddPaths (PathNoEnds ());
            }
        }

        public List<Node> PathNoEnds ()
        {
            List<Node> p = Path;
            if (Path.Count > 1)
            {
                p.Remove (Path[0]);
                p.Remove (Path[Path.Count - 1]);
            }
            return p;
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