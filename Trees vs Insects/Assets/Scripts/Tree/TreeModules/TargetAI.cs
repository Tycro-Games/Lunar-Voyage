using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class TargetAI : MonoBehaviour
    {
        private BoxCollider target;
        private ITreeRecon treeRecon;
        private ITreeShoot treeShoot;

        public void GetBoxCol()
        {
            target = treeRecon.CheckForEnemies();
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void OnDrawGizmos()
        {
            if (target != null)
                Gizmos.DrawLine(transform.position, target.transform.position);
        }

        private void Start()
        {
            treeShoot = GetComponent<ITreeShoot>();
            treeRecon = GetComponent<ITreeRecon>();
        }

        private void Update()
        {
            if (target != null && treeRecon.CheckDist(target))
            {
                treeShoot.Shoot(target.transform);
                return;
            }
            GetBoxCol();
        }
    }
}