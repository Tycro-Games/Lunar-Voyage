using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class TargetAI : MonoBehaviour
    {
        private BoxCollider target;
        private ITreeRecon treeRecon;
        private ITreeShoot treeShoot;

        public BoxCollider Target { get => target; set => target = value; }

        public void GetBoxCol()
        {
            Target = treeRecon.CheckForEnemies();
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void OnDrawGizmos()
        {
            if (Target != null)
                Gizmos.DrawLine(transform.position, Target.transform.position);
        }

        private void Start()
        {
            treeShoot = GetComponent<ITreeShoot>();
            treeRecon = GetComponent<ITreeRecon>();
        }

        private void Update()
        {
            if (Target != null && treeRecon.CheckDist(Target))
            {
                treeShoot.Shoot(Target.transform);
                return;
            }
            GetBoxCol();
        }
    }
}