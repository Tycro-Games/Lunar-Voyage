using UnityEngine;

namespace Bogadanul
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField]
        private float rotateSpeed = 1;

        private void Update()
        {
          //  Quaternion newRot =Quater transform.rotation;
          //  newRot.z = (newRot.z + Time.deltaTime * rotateSpeed) ;
            transform.RotateAround(transform.position,Vector3.forward,Time.deltaTime*rotateSpeed);
        }
    }
}