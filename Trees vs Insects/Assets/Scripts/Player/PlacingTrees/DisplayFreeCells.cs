using Bogadanul.Assets.Scripts.Enemies;
using Boo.Lang;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Bogadanul.Assets.Scripts.Player
{
    public class DisplayFreeCells : DisplayStuff
    {
        private CurrentSeedDisplay currentSeedDisplay;
        private HashSet<Node> nodes = null;
        private HashSet<Node> StartNodes = null;

        private NodeFinder nodeFinder = null;

        public override void Reset ()

        {
            nodes = new HashSet<Node> ();
        }

        public void RecheckNodes ()
        {
            Reset ();

            if (!currentSeedDisplay.IsFruit)
                foreach (Node n in StartNodes)
                {
                    if (n.TowerPlaceAble ())
                        nodes.Add (n);
                }
            else
            {
                foreach (Node n in StartNodes)
                {
                    if (n.FruitPlaceable ())
                        nodes.Add (n);
                }
            }
            nodes.Remove (nodeFinder.NodeFromInput (Pointer.current.position.ReadUnprocessedValue ()));
        }

        public void DisplayPlaceable (bool show = false)
        {
            //check
            if (StartNodes == null)
                Init ();
            if (!show)
                Reset ();
            else
                RecheckNodes ();
            int i = 0;
            foreach (Node node in nodes)
            {
                sprites[i].SetActive (true);
                sprites[i++].transform.position = node.worldPosition;
            }
            for (; i < lasti; i++)
            {
                sprites[i].SetActive (false);
            }
            lasti = i;
        }

        private void Init ()
        {
            StartNodes = new HashSet<Node> ();
            foreach (Node n in Gridmanager.Nodes.Keys)
            {
                if (n.IsWalkable)
                    StartNodes.Add (n);
            }
        }

        private void OnDisable ()
        {
            currentSeedDisplay.OnRangeDisplay -= DisplayPlaceable;
        }

        private void Start ()
        {
            MakeObjects ();
            currentSeedDisplay = FindObjectOfType<CurrentSeedDisplay> ();
            currentSeedDisplay.OnRangeDisplay += DisplayPlaceable;
            nodeFinder = GetComponent<NodeFinder> ();
        }
    }
}