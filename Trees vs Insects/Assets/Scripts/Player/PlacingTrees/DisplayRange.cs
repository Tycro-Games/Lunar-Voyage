using Bogadanul.Assets.Scripts.Enemies;
using Bogadanul.Assets.Scripts.Tree;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class DisplayRange : DisplayStuffBase
    {
        [HideInInspector]
        public List<Node> nodes = new List<Node>();

        private TreeSeedSender seedSender = null;
        private ITreeRecon treeRecon = null;

        public void DisplayTheRange(Node pos)
        {
            if (treeRecon != null && pos!=null)
            {
                nodes = treeRecon.GetNodeRange(pos);
                int i = 0;
                foreach (Node n in nodes)
                {
                    //if (!n.IsWalkable || n.IsPlanted)
                    //    continue;
                    sprites[i].SetActive(true);
                    sprites[i++].transform.position = n.worldPosition;
                }
                for (; i < lasti; i++)
                {
                    sprites[i].SetActive(false);
                }
                lasti = i;
            }
            else
            {
                Reset();
            }
        }

        public void UpdateG(TreeSeed obj)
        {
            treeRecon = obj.TreeGameObject.GetComponent<ITreeRecon>();
        }

        public void Reset()
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                sprites[i].SetActive(false);
            }
            nodes = new List<Node>();
        }

        private void OnDisable()
        {
            seedSender.OnChangeSeed -= UpdateG;
        }

        private void Awake()
        {
            MakeObjects();
        }

        private void Start()
        {
            seedSender = FindObjectOfType<TreeSeedSender>();
            seedSender.OnChangeSeed += UpdateG;
        }

        private void OnDrawGizmosSelected()
        {
            if (nodes.Count > 0)
            {
                foreach (Node n in nodes)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireSphere(n.worldPosition, .5f);
                }
            }
        }
    }
}