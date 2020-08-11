using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private EnemyCommon enemyCommon = null;

    public EnemyCommon EnemyCommon { get => enemyCommon; }
}
