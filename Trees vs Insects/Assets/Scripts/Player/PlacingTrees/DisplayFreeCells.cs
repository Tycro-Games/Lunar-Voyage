using Assets.Scripts.Tree.Interface;
using Bogadanul.Assets.Scripts.Enemies;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Bogadanul.Assets.Scripts.Player
{
    public class DisplayFreeCells : DisplayStuff
    {
        private CurrentSeedDisplay currentSeedDisplay;
        private HashSet<Node> nodes = null;
        private HashSet<Node> StartNodes;

        private NodeFinder nodeFinder = null;
        private CustomChecks check;

        private DisplayPath displayPath;

        public override void Reset()

        {
            nodes = new HashSet<Node>();
        }

        public void RecheckNodes()
        {
            Reset();

            if (currentSeedDisplay.IsFruit)
                foreach (Node n in StartNodes)
                {
                    if (n.FruitPlaceable())
                        nodes.Add(n);
                }
            else //tree
            {
                foreach (Node n in StartNodes)
                {
                    if (n.currentPlant != null)
                    {
                        check = n.currentPlant.GetComponent<CustomChecks>();
                    }
                    if (n.TowerPlaceAble())
                    {
                        if (check == null)
                        {
                            nodes.Add(n);
                        }
                        else if (check != null && check.CustomCheck(n))
                        {
                            nodes.Add(n);
                        }
                    }
                    check = null;
                }
            }

            nodes.Remove(nodeFinder.NodeFromInput(Pointer.current.position.ReadUnprocessedValue()));
        }

        public void DisplayPlaceable(bool show = false)
        {
            //check

            if (!show)
                Reset();
            else
                RecheckNodes();
            int i = 0;
            foreach (Node node in nodes)
            {
                sprites[i].SetActive(true);
                sprites[i++].transform.position = node.worldPosition;
            }
            for (; i < lasti; i++)
            {
                sprites[i].SetActive(false);
            }
            lasti = i;
        }

        public override void Init()
        {
            base.Init();
            displayPath = GetComponent<DisplayPath>();
            StartNodes = new HashSet<Node>();
            foreach (Node n in Gridmanager.Nodes.Keys)
            {
                StartNodes.Add(n);
            }
        }

        private void OnDisable()
        {
            currentSeedDisplay.OnRangeDisplay -= DisplayPlaceable;
        }

        private void Start()
        {
            Init();
            currentSeedDisplay = FindObjectOfType<CurrentSeedDisplay>();
            currentSeedDisplay.OnRangeDisplay += DisplayPlaceable;
            nodeFinder = GetComponent<NodeFinder>();
        }
    }
}