using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    [Header("Particles Système")]
    public ParticleSystem footstepParticles;

    public void Moving(bool moving, bool grounded)
    {
        if (moving && grounded)
        {
            Debug.Log("GO PARTICLES");
            footstepParticles.Play();
        }
        else
        {
            footstepParticles.Stop();
            footstepParticles.Clear();
            Debug.Log("STOP PARTICLES");
        }
    }
}
