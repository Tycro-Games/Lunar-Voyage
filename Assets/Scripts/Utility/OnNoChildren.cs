using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul
{
    public class OnNoChildren : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent onNoChildren;

        // Update is called once per frame
        void Update()
        {
            if (transform.childCount == 0)
            {
                onNoChildren?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
