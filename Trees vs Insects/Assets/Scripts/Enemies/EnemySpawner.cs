using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform target = null;
    private Grid grid = null;

    private Pathfinding pathfinding;
    void Awake()
    {
        grid = FindObjectOfType<Grid>();

        pathfinding = GetComponent<Pathfinding>();

        pathfinding.Init(target, grid);
    }
    public void Spawn(GameObject enemyPrefab)
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
        Pathfinding[] enemyPaths = enemy.GetComponentsInChildren<Pathfinding>();
        foreach (Pathfinding enemyPath in enemyPaths)
        {
            enemyPath.Init(target, grid);
        }
    }
}
