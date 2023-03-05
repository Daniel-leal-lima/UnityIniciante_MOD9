using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimationEventsDone : MonoBehaviour
{
    public ParticleSystem laserParticle;

    int i = 0;

    public void IncrementaUm()
    {
        i++;
        Debug.Log("Piscou Vermelho: " + i + " vezes!");
    }

    public void PlayVFX()
    {
        laserParticle.Stop();
        laserParticle.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        AudioSource audioPlayer = GetComponent<AudioSource>();
        if(audioPlayer != null)
        {
            audioPlayer.clip = clip;
            audioPlayer.Play();
        }
    }
}
