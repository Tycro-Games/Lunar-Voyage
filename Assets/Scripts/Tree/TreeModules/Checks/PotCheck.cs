using Assets.Scripts.Tree.Interface;
using Bogadanul.Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Tree.TreeModules
{
    public class PotCheck : MonoBehaviour, CustomChecks
    {
        public bool SameNode(Node n)
        {
            GameObject obj = n.currentPlant;
            if (obj == gameObject)
                return true;

            return false;
        }
        public bool canBePlaced(Node n)
        {
            if (n.TowerPlaceAble() && n.IsWalkable)
            {
                return true;
            }
            return false;
        }
    }
}