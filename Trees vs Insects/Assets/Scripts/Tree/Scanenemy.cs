using Bogadanul.Assets.Scripts.Enemies;
using System.Collections;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class Scanenemy : MonoBehaviour
    {
        private AncientTreeOnDestroy ancientTree = null;

        [SerializeField]
        private Vector2 radius = Vector2.zero;

        [SerializeField]
        private LayerMask enemies = 0;

        private void Start ()
        {
            ancientTree = GetComponent<AncientTreeOnDestroy> ();
        }

        private void Update ()
        {
            Scan ();
        }

        private void Scan ()
        {
            Collider[] collider = new Collider[1];
            int count = Physics.OverlapBoxNonAlloc (transform.position, radius / 2, collider, Quaternion.identity, enemies);
            if (count != 0)
            {
                EnemyInteract (collider[0]);
            }
        }

        private void EnemyInteract (Collider other)
        {
            ReachAncientTree RancientTree = other.GetComponent<ReachAncientTree> ();
            ancientTree.OnTreeReach (RancientTree.AncientTreeHealthLost);
            RancientTree.Reached ();
        }

        private void OnDrawGizmosSelected ()
        {
            Gizmos.DrawCube (transform.position, radius);
        }
    }
}