using Bogadanul.Assets.Scripts.Player;
using Bogadanul.Assets.Scripts.Utility;
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
            x = Mathf.RoundToInt (dir.x);
            y = Mathf.RoundToInt (dir.y);
        }
    }

    public class AdiacentLinesRecon : BaseRecon, ITreeRecon
    {
        private addDir direction = new addDir (new Vector2 (1, 0));

        [SerializeField]
        private float SizeOfCheck = .5f;

        public BoxCollider CheckForEnemies ()
        {
            BoxCollider[] hits = new BoxCollider[1];
            for (int i = 0; i < nodes.Count; i++)
            {
                int c = Physics.OverlapBoxNonAlloc (nodes[i].worldPosition, Vector2.one * SizeOfCheck, hits, Quaternion.identity, enemies);
                if (c > 0)
                    break;
            }
            return hits[0];
        }

        public List<Node> GetNodeRange (Node pos)
        {
            return UtilityRecon.GetLines (pos, Gridmanager.gridmanager);
        }

        private void Awake ()
        {
            GetRefs ();
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