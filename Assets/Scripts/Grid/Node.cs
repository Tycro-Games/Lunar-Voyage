using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class Node : IHeapItem<Node>
    {
        public int gCost;
        public int gridX;
        public int gridY;
        public int hCost;
        public Node parent;
        public Vector3 worldPosition;
        public GameObject currentPlant;

        //bools
        public bool IsWalkable;

        public bool IsBlocked;
        public bool IsPlanted = false;

        private int heapIndex;

        public Node(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY)
        {
            IsWalkable = _walkable;
            worldPosition = _worldPos;
            gridX = _gridX;
            gridY = _gridY;
        }

        public int fCost
        {
            get
            {
                return gCost + hCost;
            }
        }

        public int HeapIndex
        {
            get
            {
                return heapIndex;
            }
            set
            {
                heapIndex = value;
            }
        }

        public bool TowerPlaceAble()
        {
            if (!IsBlocked && !IsPlanted)
                return true;
            return false;
        }

        public bool FruitPlaceable()
        {
            if (!IsPlanted && IsWalkable)
                return true;
            return false;
        }

        public int CompareTo(Node nodeToCompare)
        {
            int compare = fCost.CompareTo(nodeToCompare.fCost);
            if (compare == 0)
            {
                compare = hCost.CompareTo(nodeToCompare.hCost);
            }
            return -compare;
        }
    }
}