using System.Collections;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class FireOnTime : MonoBehaviour, IFireRater
    {
        [SerializeField]
        private float time = 0;

        public IEnumerator Wait ()
        {
            yield return new WaitForSeconds (time);
        }
    }
}