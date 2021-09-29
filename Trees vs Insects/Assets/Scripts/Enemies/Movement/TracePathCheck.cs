using Bogadanul.Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class TracePathCheck : MonoBehaviour
    {
        protected List<Node> path = new List<Node>();
        protected List<Node> notWorking = new List<Node>();
        [SerializeField]
        private GameObject obj;
        public virtual List<Node> Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
             //   UpdateNodes(path);
            }
        }
        public  void UpdateNode()
        {
            StartCoroutine(UpdateNodes());
        }
        IEnumerator UpdateNodes()
        {
            notWorking = new List<Node>();
            foreach (Node n in path)
            {
                if (!CheckPlacerPath.CheckNode(n, obj))
                {

                    notWorking.Add(n);
                    
                }
                yield return new WaitForSeconds(1);
                EnemyManager.UpdateGrid();

            }
        }
        private void OnDrawGizmosSelected()
        {
            if (path != null)
            {
                foreach (Node n in path)
                {
                    Gizmos.color = Color.black;
                    Gizmos.DrawWireCube(n.worldPosition, Vector3.one*.5f);
                }
            }
            if (notWorking != null)
            {
                foreach (Node n in notWorking)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawWireCube(n.worldPosition, Vector3.one);
                }
            }
        }
    }
}