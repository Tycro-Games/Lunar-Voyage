using Bogadanul.Assets.Scripts.Enemies;
using System.Collections;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class Scanenemy : MonoBehaviour
    {
        private AncientTreeOnDestroy ancientTree = null;

        private void Start ()
        {
            ancientTree = GetComponent<AncientTreeOnDestroy> ();
        }

        private void OnTriggerEnter (Collider other)
        {
            if (other.CompareTag ("Enemy"))
            {
                ReachAncientTree RancientTree = other.GetComponent<ReachAncientTree> ();
                ancientTree.OnTreeReach (RancientTree.AncientTreeHealthLost);
                RancientTree.Reached ();
            }
        }
    }
}