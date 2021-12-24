using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Fmod
{
    public class VCAController : MonoBehaviour
    {
        private VCA VcaController;

        private Slider slider;

        [SerializeField]
        private string VcaName;

        private float val;

        private void Start()
        {
            slider = GetComponent<Slider>();
            SetSavedValue();
            slider.value = val;
        }

        public void SetSavedValue()
        {
            VcaController = RuntimeManager.GetVCA("vca:/" + VcaName);
            val = PlayerPrefs.GetFloat(VcaName, 1);
            VcaController.setVolume(val);
            
        }

        public void SetVolume(float val)
        {
            VcaController.setVolume(val);
            PlayerPrefs.SetFloat(VcaName, val);
            PlayerPrefs.Save();
        }
    }
}