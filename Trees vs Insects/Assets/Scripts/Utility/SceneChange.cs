using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bogadanul.Assets.Scripts.Utility
{
    public class SceneChange : MonoBehaviour
    {
        private void Update ()
        {
            if (Input.GetMouseButtonDown (1))
            {
                SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
            }
        }
    }
}