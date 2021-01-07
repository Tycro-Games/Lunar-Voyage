using Bogadanul.Assets.Scripts.Tree;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class DisplayRange : MonoBehaviour
    {
        [HideInInspector]
        public List<Node> nodes = new List<Node> ();

        private TreeSeedSender seedSender = null;
        private ITreeRecon treeRecon = null;

        public void DisplayTheRange (Node pos)
        {
            if (treeRecon != null && pos != null)
                nodes = treeRecon.GetNodeRange (pos);
            else if(pos == null)
            {
                Reset ();
            }

        }

        public void UpdateG (TreeSeed obj)
        {
            treeRecon = obj.TreeGameObject.GetComponent<ITreeRecon> ();
        }

        public void Reset ()
        {
            nodes = new List<Node> ();
        }

        private void OnDisable ()
        {
            seedSender.OnChangeSeed -= UpdateG;
        }

        private void Start ()
        {
            seedSender = FindObjectOfType<TreeSeedSender> ();
            seedSender.OnChangeSeed += UpdateG;
        }

        private void OnDrawGizmosSelected ()
        {
            if (nodes.Count > 0)
            {
                foreach (Node n in nodes)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireSphere (n.worldPosition, .5f);
                }
            }
        }
    }
}