using UnityEngine;

namespace Assets.Scripts.Enemies.Scriptable
{
    [CreateAssetMenu(fileName = "MovementSpeeds", menuName = "Create/Stats/MovementSpeeds", order = 0)]
    public class MovementSpeeds : ScriptableObject
    {
        public float unitsPerSec = 3.0f;

        public float min = 0;
        public float max = .15f;
    }
}