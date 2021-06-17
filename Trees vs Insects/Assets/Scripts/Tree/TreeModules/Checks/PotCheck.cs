using Assets.Scripts.Tree.Interface;
using Bogadanul.Assets.Scripts.Player;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Tree.TreeModules
{
    public class PotCheck : MonoBehaviour, CustomChecks
    {
        public bool CustomCheck(Node n)
        {
            if (n.currentPlant?.GetComponent<PotCheck>() != null)
            {
                return false;
            }
            return true;
        }
    }
}