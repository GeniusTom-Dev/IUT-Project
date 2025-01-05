using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

namespace BUT {
    public class SoundManager : MonoBehaviour
    {
        [Header("Audio")]
        public AudioSource playerAudioSource;
        public AudioSource playerWalkAudioSource;
        public AudioSource gameAudioSource;

        [Header("Event")]
        public AudioClip walk;
        public AudioClip jump;
        public AudioClip coin;
        public AudioClip swordSlash;
        public AudioClip swordTaking;
        public AudioClip win;
        public AudioClip death;
        public AudioClip teleport;

        [Header("Ambient")]
        public AudioClip ambient;
        public AudioClip fight;

        private bool hasWin = false;

        void Start()
        {
            SetAmbientSound(false);
        }

        public void SetAmbientSound(bool isInFight, bool active = true)
        {
            AudioClip audioClip = isInFight ? fight : ambient;
            if (audioClip != null && gameAudioSource.clip == audioClip && gameAudioSource.isPlaying == active) return;
            gameAudioSource.clip = audioClip;
            gameAudioSource.loop = true; // Boucle le son pour une marche continue
            if (active) {
                gameAudioSource.Play();
            }
            else
            {
                gameAudioSource.Stop();
            }
        }

        public void Moving(bool moving, bool grounded)
        {
            if (hasWin) return;
            if (moving && grounded)
            {
                playerWalkAudioSource.clip = walk;
                playerWalkAudioSource.loop = true; // Boucle le son pour une marche continue
                playerWalkAudioSource.Play();
            }
            else
            {
                playerWalkAudioSource.Stop();
            }
        }

        public void PlayOneTime(string soundName)
        {
            AudioClip audio = null;

            if (hasWin) return;

            switch (soundName)
            {
                case "coin":
                    audio = coin;
                    break;
                case "jump":
                    audio = jump;
                    break;
                case "SwordState":
                    audio = swordTaking;
                    break;
                case "SwordSlash":
                    audio = swordSlash;
                    break;
                case "teleport":
                    audio = teleport;
                    break;
                case "death":
                    audio = death;
                    break;
                case "win":
                    audio = win;
                    hasWin = true;
                    SetAmbientSound(false, false);
                    break;

            }

            if (audio == null) return;

            playerAudioSource.clip = audio;
            playerAudioSource.loop = false;
            playerAudioSource.Play();
        }
    }
}
