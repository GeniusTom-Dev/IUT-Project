using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    [Header("Particles System")]
    public ParticleSystem footstepParticles;

    public void Moving(bool moving, bool grounded)
    {
        if (moving && grounded)
        {
            footstepParticles.Play();
        }
        else
        {
            footstepParticles.Stop();
            footstepParticles.Clear();
        }
    }
}
