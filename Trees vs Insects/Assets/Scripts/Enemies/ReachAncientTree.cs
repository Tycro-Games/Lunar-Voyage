using Bogadanul.Assets.Scripts.Tree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class ReachAncientTree : MonoBehaviour
    {
        [SerializeField]
        private int ancientTreeHealthLost = 1;

        [SerializeField]
        private LayerMask layerMask = 0;

        public void Reached ()
        {
            Collider[] col = new Collider[1];
            int count = Physics.OverlapBoxNonAlloc (transform.position, Vector3.one, col, Quaternion.identity, layerMask);
            if (count != 0)
                col[0].GetComponent<AncientTreeOnDestroy> ().OnTreeReach (ancientTreeHealthLost);
            else
                Debug.LogError ("There is no tree");
            Destroy (gameObject);
        }
    }
}