using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TreePlacer : MonoBehaviour
{
    GameObject obj;
    private void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

        if (Physics.Raycast (ray, out RaycastHit hit))
        {
            obj = hit.collider.gameObject;
        }
            
    }
    private void OnDrawGizmos ()
    {
        if (obj)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube (obj.transform.position, Vector3.one*1.25f);

        }
    }
}
