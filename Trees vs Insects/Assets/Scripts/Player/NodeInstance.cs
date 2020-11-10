using UnityEngine;
using System.Collections;

namespace Bogadanul.Assets.Scripts.Player
{
    public class NodeInstance : MonoBehaviour
    {
        [HideInInspector]
        public Node node = null;

        [SerializeField]
        private LayerMask ocupieable = 0;

        private Collider[] res = new Collider[1];

        public void Init (Node node)
        {
            this.node = node;
        }

        private void Update ()
        {
            int count = Physics.OverlapSphereNonAlloc (transform.position, 1, res, ocupieable);
            if (count > 0)
            {
                node.Ocupied = true;
            }
            else
                node.Ocupied = false;
        }

        private void OnDrawGizmos ()
        {
            Gizmos.color = Color.red;
            if (node?.Ocupied == true)
                Gizmos.DrawWireCube (transform.position, Vector2.one * 2);
        }
    }
}