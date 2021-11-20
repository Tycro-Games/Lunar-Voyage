using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Tree.Projectiles.Modules
{
    public class ArcMovement : MonoBehaviour
    {
        public AnimationCurve curve;

        [SerializeField]
        private float duration = 1.0f;

        public IEnumerator Curve(Vector3 start, Vector2 target, float heightY = 3.0f)
        {
            float time = 0f;

            Vector2 end = target;
            //temp vars
            while (time < duration)
            {
                time += Time.deltaTime;

                float linearT = time / duration;
                float heightT = curve.Evaluate(linearT);

                float height = Mathf.Lerp(0f, heightY, heightT);

                transform.position = Vector2.Lerp(start, end, linearT) + new Vector2(0f, height);

                yield return null;
            }
        }
    }
}