using UnityEngine;
using TouchPhase = UnityEngine.TouchPhase;

public class TreePlacer : MonoBehaviour
{
    GameObject obj;
    [SerializeField]
    private LayerMask grid = 0;

    [SerializeField]
    private GameObject currentTree = null;

    private void Update()
    {
#if UNITY_ANDROID
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hit, 100, grid))
                {
                    if (hit.transform.tag == "grid")
                    {
                        obj = hit.collider.gameObject;
                        CheckToPlace();
                    }
                }
            }
        }
#endif
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100, grid))
            {
                if (hit.transform.tag == "grid")
                {
                    obj = hit.collider.gameObject;
                    CheckToPlace();
                }
            }

        }
#endif
    }
    public void CheckToPlace()
    {
        if (obj.transform.childCount != 0)
            return;

        EnemyManager.hasPath = false;


        GameObject currentPlace = Instantiate(currentTree, obj.transform.position, Quaternion.identity, obj.transform);
        EnemyManager.CheckSpace();



        if (!EnemyManager.hasPath)
        {
            Destroy(currentPlace);
            EnemyManager.CheckSpace();
            return;
        }


    }
    private void OnDrawGizmos()
    {
        if (obj)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireCube(obj.transform.position, Vector3.one * 1);
        }
    }
}
