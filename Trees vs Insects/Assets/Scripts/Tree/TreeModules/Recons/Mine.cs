using Bogadanul.Assets.Scripts.Enemies;
using Bogadanul.Assets.Scripts.Utility;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul.Assets.Scripts.Tree.TreeModules.Recons
{
    [RequireComponent (typeof (Explode))]
    [RequireComponent (typeof (DestroyTree))]
    public class Mine : BaseRangeSearch
    {
        private DestroyTree destroyTree = null;

        [SerializeField]
        private UnityEvent OnDetect = null;

        private void Start ()
        {
            destroyTree = GetComponent<DestroyTree> ();
        }

        private void Update ()
        {
            Searching ();
        }

        private void Searching ()
        {
            Collider[] colliders = new Collider[1];
            int count = Physics.OverlapSphereNonAlloc (transform.position, range, colliders, enemies);

            if (count != 0)
            {
                OnDetect?.Invoke ();
            }
        }
    }
}