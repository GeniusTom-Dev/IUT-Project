using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUT {
    public class SoundManager : MonoBehaviour
    {
        [Header("Audio")]
        public AudioSource audioSource;
        public AudioClip walkClip;
        public AudioClip jumpClip;

        public void Moving(bool moving, bool grounded)
        {
            if (moving && grounded)
            {
                audioSource.clip = walkClip;
                audioSource.loop = true; // Boucle le son pour une marche continue
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }

        public void Jump()
        {
            audioSource.clip = jumpClip;
            audioSource.loop = false;
            audioSource.Play();
        }
    }
}
