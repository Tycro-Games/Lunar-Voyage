using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bogadanul.Assets.Scripts.Utility
{
    public class SceneChange : MonoBehaviour
    {
        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void LoadSceneSi(string name)
        {
            if (name.Length > 0)
                SceneManager.LoadScene(name);
        }

        public void LoadSceneAd(string name)
        {
            SceneManager.LoadScene(name, LoadSceneMode.Additive);
        }

        public void UnloadScene(string name)
        {
            SceneManager.UnloadSceneAsync(name);
        }

        public void LoadNextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}