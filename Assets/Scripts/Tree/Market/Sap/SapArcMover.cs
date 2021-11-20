using Assets.Scripts.Tree.Projectiles.Modules;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Tree.Market.Sap
{
    public class SapArcMover : MonoBehaviour
    {
        private ArcMovement arcMovement = null;

        [SerializeField]
        private float range = 1;

        private void Start()
        {
            arcMovement = GetComponent<ArcMovement>();
            RandomPoint();
        }

        private void RandomPoint()
        {
            Vector2 pos = (Vector2)transform.position + Random.insideUnitCircle * range;
            StartCoroutine(arcMovement.Curve(transform.position, pos));
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}