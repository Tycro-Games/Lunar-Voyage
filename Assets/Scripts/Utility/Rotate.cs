using UnityEngine;

namespace Bogadanul
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField]
        private float rotateSpeed = 1;
        [SerializeField]
        private float minFloat=50;
        [SerializeField]
        private float maxFloat=100;
        private void Start()
        {
            minFloat = rotateSpeed;

        }
        private void Update()
        {
            transform.RotateAround(transform.position,Vector3.forward,Time.deltaTime*rotateSpeed);
        }

        public void ChangeSpeed(float interpolation)
        {
            rotateSpeed = Mathf.Lerp(minFloat, maxFloat, interpolation);
        }
    }
}