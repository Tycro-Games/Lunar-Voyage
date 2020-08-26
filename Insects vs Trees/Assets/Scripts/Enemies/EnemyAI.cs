using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private EnemyHealth enemyHP;
    private void Start()
    {
        enemyHP = GetComponent<EnemyHealth>();
    }
    public void TakeDamage(int dg)
    {
        enemyHP.TakeDamage(dg);
    }
}
