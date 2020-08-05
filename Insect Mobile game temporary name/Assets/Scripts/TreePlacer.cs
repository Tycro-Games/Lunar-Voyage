using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TreePlacer : MonoBehaviour
{
    GameObject obj;
    [SerializeField]
    private LayerMask grid = 0;

    [SerializeField]
    private GameObject currentTree = null;

    public delegate void onPlaceTree ();
    public static event onPlaceTree OnPlaceTree;

    private void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast (ray, out RaycastHit hit, 100, grid))
        {
            obj = hit.collider.gameObject;
        }


    }
    public void CheckToPlace (InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            GameObject currentPlace = Instantiate (currentTree, obj.transform.position, Quaternion.identity);
            OnPlaceTree ();



            if (!Pathfinding.hasPath)
            {
                Destroy (currentPlace);
                OnPlaceTree ();
                return;
            }
           
        }
    }
    private void OnDrawGizmos ()
    {
        if (obj)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireCube (obj.transform.position, Vector3.one * 1);
        }
    }
}
