using Bogadanul.Assets.Scripts.Utility;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class Seed : MonoBehaviour
    {
        [SerializeField]
        private int seed = 0;

        private RandomNumberGenerator random;

        public void NewGenerator ()
        {
            if (seed != 0)
                random = new RandomNumberGenerator (seed);
            else
                random = new RandomNumberGenerator ();
        }

        private void Start ()
        {
            NewGenerator ();
        }
    }
}