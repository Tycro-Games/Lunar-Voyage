using UnityEngine;

public class CheckPlacerPath : MonoBehaviour
{


    public void CheckToPlace(GameObject cell, GameObject currentTree)
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
