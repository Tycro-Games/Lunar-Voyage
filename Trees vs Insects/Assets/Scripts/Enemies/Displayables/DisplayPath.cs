using Bogadanul.Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class DisplayPath : DisplayStuff
    {
        private Node currentNode = null;
        private NodeFinder nodeFinder = null;

        public void Display (List<Node> nodes)
        {
            UpdateDisplays (nodes);
            int i = 0;
            foreach (Node node in displayPathManager.nodes)
            {
                if (node == currentNode)
                    break;
                sprites[i].SetActive (true);
                sprites[i++].transform.position = node.worldPosition;
            }
            for (; i < lasti; i++)
            {
                sprites[i].SetActive (false);
            }
            lasti = i;
        }

        public void UpdateDisplays (List<Node> nodes)
        {
            Reset ();
            displayPathManager.AddPaths (nodes);
            currentNode = nodeFinder.NodeFromInput (Pointer.current.position.ReadUnprocessedValue ());
        }

        private void OnDisable ()
        {
            EnemyManager.OnNoSpace -= Display;
        }

        private void OnEnable ()
        {
            EnemyManager.OnNoSpace += Display;
        }

        private void Awake ()
        {
            nodeFinder = GetComponent<NodeFinder> ();
            MakeObjects ();
            displayPathManager = new DisplayPathManager ();
        }
    }
}