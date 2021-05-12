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
            audioMixer.GetFloat("Volume", out float val);
            GetComponent<Slider>().value = val;
        }

        public void SetVolume(float volume)
        {
            audioMixer.SetFloat("Volume", volume);
        }
    }
}