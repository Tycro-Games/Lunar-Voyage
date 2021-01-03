using Bogadanul.Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    [System.Serializable]
    public struct addDir
    {
        public int x;
        public int y;

        public addDir (Vector2 dir)
        {
            this.x = Mathf.RoundToInt (dir.x);
            this.y = Mathf.RoundToInt (dir.y);
        }
    }

    public class SingleLineRecon : BaseRecon, ITreeRecon
    {
        private addDir direction;

        private Gridmanager gridmanager;
        private Transform tree = null;
        private TreeShotNoTarget treeShot = null;
        public addDir Direction { get => direction; set => direction = value; }

        public BoxCollider CheckForEnemies ()
        {
            BoxCollider[] hits = new BoxCollider[1];
            for (int i = 0; i < nodes.Count; i++)
            {
                int c = Physics.OverlapBoxNonAlloc (nodes[i].worldPosition, Vector2.one, hits, Quaternion.identity, enemies);
                if (c > 0)
                    break;
            }
            return hits[0];
        }

        private void SetDir ()
        {
            Vector2 dir = transform.position - tree.position;
            dir.x *= 2;
            direction = new addDir (dir.normalized);
            treeShot.dir = new Vector2 (direction.x, direction.y);
        }

        private void Start ()
        {
            treeShot = GetComponent<TreeShotNoTarget> ();
            GetRefs ();
            tree = GameObject.Find ("AncientTree").transform;
            gridmanager = FindObjectOfType<Gridmanager> ();

            SetDir ();
            nodes = GetLine (nodeFinder.NodeFromPoint (transform), Direction);
        }

        private List<Node> GetLine (Node node, addDir coord)
        {
            List<Node> line = new List<Node> ();

            int xGrid = node.gridX;
            int yGrid = node.gridY;

            while (xGrid >= 0 && xGrid < gridmanager.gridSizeX && yGrid >= 0 && yGrid < gridmanager.gridSizeY)
            {
                line.Add (gridmanager.grid[xGrid, yGrid]);
                xGrid += coord.x;
                yGrid += coord.y;
            }
            return line;
        }

        private void OnDrawGizmosSelected ()
        {
            if (nodes.Count > 0)
            {
                foreach (Node n in nodes)
                {
                    Gizmos.DrawWireSphere (n.worldPosition, .5f);
                }
            }
        }
    }
}