using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class TreeAI : MonoBehaviour
    {
        private BoxCollider target;
        private TreeRecon treeRecon;
        private ITreeShoot treeShoot;

        public void GetBoxCol ()
        {
            BoxCollider colTarget = treeRecon.CheckSorounding ();
            target = colTarget;
        }

        private void OnDisable ()
        {
            StopAllCoroutines ();
        }

        private void OnDrawGizmos ()
        {
            if (target != null)
                Gizmos.DrawLine (transform.position, target.transform.position);
        }

        private void Start ()
        {
            treeShoot = GetComponent<ITreeShoot> ();
            treeRecon = GetComponent<TreeRecon> ();
        }

        private void Update ()
        {
            if (target != null && treeRecon.CheckDist (target))
            {
                treeShoot.Shoot (target.transform);
                return;
            }
            GetBoxCol ();
        }
    }
}