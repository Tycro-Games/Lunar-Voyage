using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class RotateTo : MonoBehaviour
    {
        [SerializeField]
        private Transform TransformToRotate = null;

        [SerializeField]
        private float speedRotation = 100.0f;

        private TargetAI TargetAI;

        private void Start()
        {
            TargetAI = GetComponent<TargetAI>();
        }

        private void Update()
        {
            if (TargetAI.Target != null)
                Rotate(TargetAI.Target.transform);
        }

        public void Rotate(Transform target)
        {
            Quaternion newRot = Quaternion.LookRotation(Vector3.forward, (target.position - transform.position).normalized);

            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * speedRotation);
        }
    }
}