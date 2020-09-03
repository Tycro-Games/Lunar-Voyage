using UnityEngine;

public class CheckPlacerPath : MonoBehaviour, ICheckPlacer
{
    [SerializeField]
    private GameObject currentTree = null;

    public GameObject CurrentTree { get => currentTree; set => currentTree = value; }

    public void CheckToPlace(GameObject cell)
    {
        if (cell == null)
            return;
        if (cell.transform.childCount != 0)
            return;

        EnemyManager.hasPath = false;

        GameObject currentPlace = Instantiate(currentTree, cell.transform.position, Quaternion.identity, cell.transform);
        EnemyManager.CheckSpace();

        if (!EnemyManager.hasPath)
        {
            Destroy(currentPlace);
            EnemyManager.CheckSpace();
            return;
        }
    }
}
