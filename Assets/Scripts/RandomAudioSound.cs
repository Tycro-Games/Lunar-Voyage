using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul
{
    public class RandomAudioSound : MonoBehaviour
    {
        [SerializeField]
        private AudioClip[] clips;
        private AudioSource audioSource;
        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }
        public void PlayARandomSound()
        {
            audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
        }
    }
}
