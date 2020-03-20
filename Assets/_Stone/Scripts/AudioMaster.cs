using UnityEngine;
using System.Collections;
using System;

namespace _Stone.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioMaster : MonoBehaviour
    {
        public static AudioMaster instace { get; private set; }
        [SerializeField] private AudioSource _AudioSorce => GetComponent<AudioSource>();

        private void Start()
        {

            instace = this;
        }

        internal void PlaySound(AudioClip sound)
        {
            _AudioSorce.clip = sound;
            _AudioSorce.Play();
        }
    }

}
