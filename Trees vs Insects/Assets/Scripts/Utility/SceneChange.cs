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
        public void LoadSceneSi(string name)
        {
            SceneManager.LoadScene(name);
        }
        public void LoadNextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}