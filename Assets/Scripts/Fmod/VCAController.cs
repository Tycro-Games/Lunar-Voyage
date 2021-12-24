using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Fmod
{
    public class VCAController : MonoBehaviour
    {
        VCA VcaController;
     
        private Slider slider;
        [SerializeField]
        private string VcaName;
        private void Start()
        {
            slider = GetComponent<Slider>();
            VcaController = RuntimeManager.GetVCA("vca:/"+ VcaName);
            float val = PlayerPrefs.GetFloat(name, 0);
            VcaController.setVolume(val);
            slider.value = val;
        }
        public void SetVolume(float val)
        {
            VcaController.setVolume(val);
            PlayerPrefs.SetFloat(name, val);
            PlayerPrefs.Save();
        }
    }
}