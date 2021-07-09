using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI
{
    public class SetVolumeOnMixer : MonoBehaviour
    {
        public AudioMixer audioMixer;

        private void Start()
        {
            float val = PlayerPrefs.GetFloat(name, 0);
            audioMixer.SetFloat("Volume", val);

            GetComponent<Slider>().value = val;
        }

        public void SetVolume(float volume)
        {
            audioMixer.SetFloat("Volume", volume);
            PlayerPrefs.SetFloat(name, volume);
            PlayerPrefs.Save();
        }
    }
}