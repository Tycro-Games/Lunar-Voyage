using System.Linq;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class EnemyChooser : MonoBehaviour
    {
        private EnemySpawnable[] enemies = null;

        public EnemySpawnable ChooseEnemy(int maxWeight)
        {
            EnemySpawnable[] temp = enemies.OrderBy(x => x.weight).ToArray();
            temp = enemies.Where(en => en.weight <= maxWeight).ToArray();
            
            return temp[Random.Range(0, temp.Length)]; 
        }

        public void Init(EnemySpawnable[] _enemies)
        {
            enemies = _enemies;
        }
    }
}