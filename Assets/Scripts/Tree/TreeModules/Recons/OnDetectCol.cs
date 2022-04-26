using Bogadanul.Assets.Scripts.Enemies;
using Bogadanul.Assets.Scripts.Utility;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul.Assets.Scripts.Tree.TreeModules.Recons
{
    public class OnDetectCol : BaseRangeSearch
    {
        [SerializeField]
        private UnityEvent OnDetect = null;

        private void Update()
        {
            Searching();
        }

        private void Searching()
        {
            Collider[] colliders = new Collider[1];
            int count = Physics.OverlapSphereNonAlloc(transform.position, range, colliders, dedectable);

            if (count != 0)
            {
                OnDetect?.Invoke();
            }
        }
    }
}