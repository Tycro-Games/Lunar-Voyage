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
            GameObject obj = n.currentPlant;
            if (obj != null)
                if (obj.TryGetComponent(out PotCheck potCheck))
                {
                    return false;
                }
            return true;
        }
    }
}