using Bogadanul.Assets.Scripts.Player;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class NodeFinder : MonoBehaviour
    {
        private Gridmanager theGrid = null;

        [SerializeField]
        private LayerMask layerToPlace = 0;

        private Camera cam;

        public Node NodeFromPoint (Vector2 position)
        {
            if (Physics.Raycast (cam.ScreenPointToRay (position), out RaycastHit hit, 50, layerToPlace)
                &&
                hit.collider.gameObject.CompareTag ("grid"))
            {
                Node n = hit.collider.GetComponent<NodeInstance> ().node;
                if (!n.Ocupied)
                    return n;
            }
            return null;
        }

        private void Start ()
        {
            cam = Camera.main;
            theGrid = FindObjectOfType<Gridmanager> ();
        }
    }
}