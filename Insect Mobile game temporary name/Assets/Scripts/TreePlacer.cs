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
        
        if (Input.GetMouseButtonDown (0))
        {
            if (Physics.Raycast (ray, out RaycastHit hit, 100, grid))
            {
                if (hit.transform.tag == "grid")
                {
                    obj = hit.collider.gameObject;
                    CheckToPlace ();
                } 
            }
            
        }
    }
    public void CheckToPlace ()
    {
        if (obj.transform.childCount != 0)
            return;

        EnemyManager.hasPath = false;


        GameObject currentPlace = Instantiate (currentTree, obj.transform.position, Quaternion.identity, obj.transform);
        OnPlaceTree ();



        if (!EnemyManager.hasPath)
        {
            Destroy (currentPlace);
            OnPlaceTree ();
            return;
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
