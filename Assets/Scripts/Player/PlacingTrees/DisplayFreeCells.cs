using Bogadanul.Assets.Scripts.Enemies;
using System.Collections;
using System.Collections.Generic;
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
                    if (n.TowerPlaceAble())
                    {
                        nodes.Add(n);
                    }
                }

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

                foreach (Node n in OnlyOnePathTiles)
                {
                    nodes.Remove(n);
                }
            }
            nodes.Remove(nodeFinder.NodeFromInput(Pointer.current.position.ReadUnprocessedValue()));
        }

        public void SetOnlyPaths(bool val)
        {
            StartCoroutine(UpdateNodes());
        }

        private IEnumerator UpdateNodes()
        {
            yield return null;
            OnlyOnePathTiles = new HashSet<Node>();
            int count = 0;
            foreach (Node n in displayPath.UpdateDisplaysReturnNode())
            {
                if (!n.IsBlocked)
                {
                    count++;
                    if (!CheckPlacerPath.CheckNode(n))
                    {
                        OnlyOnePathTiles.Add(n);
                    }
                }
            }
            Debug.Log(count + " calls " + OnlyOnePathTiles.Count);
            RecheckNodes();
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
            //currentSeedDisplay.OnPlace -= SetOnlyPaths;
            EnemyManager.OnEnemySet -= SetOnlyPaths;
        }

        private void Start()
        {
            Init();
            currentSeedDisplay = FindObjectOfType<CurrentSeedDisplay>();
            //   currentSeedDisplay.OnPlace += SetOnlyPaths;
            EnemyManager.OnEnemySet += SetOnlyPaths;
            currentSeedDisplay.OnRangeDisplay += DisplayPlaceable;
            nodeFinder = GetComponent<NodeFinder>();
        }

        private void OnDrawGizmos()
        {
            if (OnlyOnePathTiles.Count != 0)
            {
                foreach (Node n in OnlyOnePathTiles)
                {
                    Gizmos.DrawWireCube(n.worldPosition, 1 * Vector2.one);
                }
            }
        }
    }
}