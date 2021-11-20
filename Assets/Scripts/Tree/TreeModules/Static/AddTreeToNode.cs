using Bogadanul.Assets.Scripts.Player;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Tree.TreeModules.Static
{
    public class AddTreeToNode : MonoBehaviour
    {
        private NodeFinder nodeFinder = null;

        private void Start()
        {
            nodeFinder = GetComponent<NodeFinder>();
            Node n = nodeFinder.NodeFromPoint(transform);
            n.currentPlant = gameObject;
        }
    }
}