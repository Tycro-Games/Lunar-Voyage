using UnityEngine;
[RequireComponent(typeof(EnemyAI))]
public class EnemyAIInheritence : MonoBehaviour
{
    protected EnemyAI enemyAI = null;
    void Awake()
    {
        enemyAI = GetComponent<EnemyAI>();
    }
}
