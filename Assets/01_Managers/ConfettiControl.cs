using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiControl : MonoBehaviour
{
    static ParticleSystem particles;

    private void Awake()
    {
        particles = GetComponent<ParticleSystem>();
    }

    public static void PlayConfetti()
    {
        particles.Play();
    }
}
