
using System;
using UnityEngine;
using System.Linq;
public class EnemyChooser : MonoBehaviour
{
    private EnemySpawnable[] enemies = null;
    public void Init(EnemySpawnable[] _enemies)
    {
        enemies = _enemies;
    }
    public int ChooseEnemy(int maxWeight)
    {
        EnemySpawnable[] temp = enemies.Where(en => en.weight <= maxWeight).ToArray();

        int index = UnityEngine.Random.Range(0, temp.Length);

        return index;
    }
}
