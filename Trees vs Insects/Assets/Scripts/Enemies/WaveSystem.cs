using System.Collections;
using UnityEngine;
[System.Serializable]
public struct Wave
{
    public float duration;
    public int weight;
    public Wave(float _duration, int _weight)
    {
        duration = _duration;
        weight = _weight;
    }
}
public class WaveSystem : MonoBehaviour
{
    private int count;
    private Seed seed;
    private EnemyChooser enemyChooser;
    private TriggerSpawner trigger;
    private EnemyListChecker enemyListChecker;
    [Header("Waves")]
    [SerializeField]
    private Wave[] waves = null;
    private int currentWave = 0;
    [Header("Enemies")]
    [SerializeField]
    private EnemySpawnable[] enemySpawnable = null;
    [SerializeField]
    private int MaxEnemyWeight = 10;
    private void Awake()
    {
        enemyListChecker = GetComponent<EnemyListChecker>();
    }
    private void OnEnable()
    {
        enemyListChecker.OnNoEnemies += randomSpawner;
    }
    private void OnDisable()
    {
        enemyListChecker.OnNoEnemies -= randomSpawner;
    }
    private void Start()
    {

        seed = GetComponent<Seed>();
        enemyChooser = GetComponent<EnemyChooser>();
        trigger = GetComponent<TriggerSpawner>();

        //how to send some variables of arrays
        enemyChooser.Init(enemySpawnable);
    }


    public void randomSpawner()
    {
        if (currentWave < waves.Length)
        {
            MaxEnemyWeight = waves[currentWave].weight;

            StartCoroutine(RandomSpawner(MaxEnemyWeight));
            currentWave++;

        }
    }
    public IEnumerator RandomSpawner(int enemyWeight)
    {
        while (enemyWeight >= 0)
        {
            EnemySpawner spawner = trigger.ChooseASpawner();

            int index = enemyChooser.ChooseEnemy(enemyWeight);


            enemyWeight -= enemySpawnable[index].weight;
            if (enemyWeight < 0)
                continue;

            GameObject enemy = enemySpawnable[index].enemyGameObject;
            spawner.Spawn(enemy);

            yield return new WaitForSeconds(.5f);
        }
    }
}
