using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class DisplayStuffBase : MonoBehaviour
    {
        [SerializeField]
        protected GameObject sprite = null;

        protected int lasti;

        [SerializeField]
        protected int count = 128;

        protected GameObject[] sprites;

        public void MakeObjects ()
        {
            lasti = 0;
            sprites = new GameObject[count];
            for (int i = 0; i < count; i++)
            {
                GameObject s = Instantiate (sprite, transform);
                s.SetActive (false);
                sprites[i] = s;
            }
        }
    }
}