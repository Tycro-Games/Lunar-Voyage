using UnityEngine;
using System.Collections;

namespace Bogadanul.Assets.Scripts.Player
{
    public class NodeInstance : MonoBehaviour
    {
        [HideInInspector]
        private Node node = null;

        [SerializeField]
        private LayerMask ocupieable = 0;

        [SerializeField]
        private LayerMask trees = 0;

        private Collider[] res = new Collider[1];

        public Node Nodey
        {
            get => node;
            set
            {
                node = value;
            }
        }

        public void Init (Node node)
        {
            Nodey = node;
        }

        private void Update ()
        {
            int count = Physics.OverlapSphereNonAlloc (transform.position, 1, res, ocupieable);
            if (count > 0)
            {
                Nodey.IsBlocked = true;
            }
            else
                Nodey.IsBlocked = false;

            bool plant = Physics.OverlapSphereNonAlloc (transform.position, 1, res, trees) > 0;
            if (plant)
            {
                Nodey.IsPlanted = true;
            }
            else
                Nodey.IsPlanted = false;
        }

        private void OnDrawGizmos ()
        {
            Gizmos.color = Color.red;
            if (Nodey?.IsBlocked == true)
                Gizmos.DrawWireCube (transform.position, Vector2.one * 2);
        }
    }
}