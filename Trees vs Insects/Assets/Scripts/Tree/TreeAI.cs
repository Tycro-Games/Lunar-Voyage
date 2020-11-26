using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class TreeAI : MonoBehaviour
    {
        private BoxCollider target;
        private ITreeRecon treeRecon;
        private ITreeShoot treeShoot;

        public void GetBoxCol ()
        {
            target = treeRecon.CheckSorounding ();
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
            treeRecon = GetComponent<ITreeRecon> ();
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