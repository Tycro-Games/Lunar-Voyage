using Assets.Scripts.Tree.Interface;
using Bogadanul.Assets.Scripts.Enemies;
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
        private HashSet<Node> StartNodes;

        private NodeFinder nodeFinder = null;
        private CustomChecks check;

        private ShowPaths displayPath;

        [SerializeField]
        private GameObject obj;

        public HashSet<Node> OnlyOnePathTiles = new HashSet<Node>();

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
            else if (currentSeedDisplay.potCheck == null)//tree
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
                        else if (check != null && check.SameNode(n))
                        {
                            nodes.Add(n);
                        }
                    }
                    check = null;
                }
                // nodes.Remove(nodeFinder.NodeFromInput(Pointer.current.position.ReadUnprocessedValue()));

                foreach (Node n in OnlyOnePathTiles)
                {
                    nodes.Remove(n);
                }
            }
            else //potty
            {
                foreach (Node n in StartNodes)
                {

                    if (currentSeedDisplay.potCheck.canBePlaced(n))
                    {
                        nodes.Add(n);
                    }
                }
               // nodes.Remove(nodeFinder.NodeFromInput(Pointer.current.position.ReadUnprocessedValue()));

                foreach (Node n in OnlyOnePathTiles)
                {
                    nodes.Remove(n);
                }
            }
            nodes.Remove(nodeFinder.NodeFromInput(Pointer.current.position.ReadUnprocessedValue()));
        }

        public void SetOnlyPaths(bool val)
        {
            if (val)
                StartCoroutine(UpdateNodes(displayPath.displayPathManager.nodes));
        }

        private IEnumerator UpdateNodes(HashSet<Node> path)
        {
            OnlyOnePathTiles = new HashSet<Node>();
            foreach (Node n in DisplayPathManager.ReturnPathWithNoHeads(path.ToList()))
            {
                if (!CheckPlacerPath.CheckNode(n, obj))
                {
                    OnlyOnePathTiles.Add(n);
                }

                yield return null;
            }
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

            displayPath = GetComponent<ShowPaths>();
            StartNodes = new HashSet<Node>();
            foreach (Node n in Gridmanager.Nodes.Keys)
            {
                StartNodes.Add(n);
            }
        }

        private void OnDisable()
        {
            currentSeedDisplay.OnRangeDisplay -= DisplayPlaceable;
            currentSeedDisplay.OnPlace -= SetOnlyPaths;
            EnemyManager.OnEnemySet -= SetOnlyPaths;
        }

        private void Start()
        {
            Init();
            currentSeedDisplay = FindObjectOfType<CurrentSeedDisplay>();
            currentSeedDisplay.OnPlace += SetOnlyPaths;
            EnemyManager.OnEnemySet += SetOnlyPaths;
            currentSeedDisplay.OnRangeDisplay += DisplayPlaceable;
            nodeFinder = GetComponent<NodeFinder>();
        }
    }
}