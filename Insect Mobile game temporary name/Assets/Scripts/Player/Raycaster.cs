using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private GameObject cell;

    [SerializeField]
    private LayerMask grid = 0;
    public GameObject Raycast(Vector3 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        if (Physics.Raycast(ray, out RaycastHit hit, 100, grid))
        {
            if (hit.transform.tag == "grid")
            {
                cell = hit.collider.gameObject;

                return cell;
            }
        }
        return null;
    }
    private void OnDrawGizmos()
    {
        if (cell)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireCube(cell.transform.position, Vector3.one * 1);
        }
    }
}
