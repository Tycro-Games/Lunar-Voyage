using UnityEngine;

public class CheckPlacerPath : MonoBehaviour
{
    public bool CheckToPlace(GameObject cell, GameObject currentTree)
    {
        if (cell == null || cell.transform.childCount != 0)
            return false;


        EnemyManager.hasPath = false;

        GameObject currentPlace = Instantiate(currentTree, cell.transform.position, Quaternion.identity, cell.transform);
        EnemyManager.CheckSpace();
        if (!EnemyManager.hasPath)
        {
            Destroy(currentPlace);
            EnemyManager.CheckSpace();
            return false;
        }
        return true;

    }
}
