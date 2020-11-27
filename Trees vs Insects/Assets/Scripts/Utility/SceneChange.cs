using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bogadanul.Assets.Scripts.Utility
{
    public class SceneChange : MonoBehaviour
    {
        public void ReloadScene ()
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
        }
    }
}