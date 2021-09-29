using Assets.Scripts.Tree.Interface;
using Bogadanul.Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Tree.TreeModules
{
    public class PotCheck : MonoBehaviour, CustomChecks
    {
        public bool CustomCheck(Node n)
        {
            GameObject obj = n.currentPlant;
            if (obj == gameObject)
                return true;

            return false;
        }
    }
}