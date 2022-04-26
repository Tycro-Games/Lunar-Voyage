using UnityEngine;
using TMPro;

namespace UI
{
    public class SetQuality : MonoBehaviour
    {
        private string QualityKey = "Quality";

        [SerializeField]
        private TMP_Dropdown quality;

        private void Start()
        {
            int index = PlayerPrefs.GetInt(QualityKey, 1);
            QualitySettings.SetQualityLevel(index);
            quality.value = index;
        }

        public void SetQualitySettings(int index)
        {
            QualitySettings.SetQualityLevel(index);
            PlayerPrefs.SetInt(QualityKey, index);
            PlayerPrefs.Save();
        }
    }
}