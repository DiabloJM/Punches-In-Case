using System;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    private bool isAudio1Playing = true;

    void Start()
    {
        // Iniciar la reproducción del primer AudioSource
        audioSource1.Play();
        audioSource2.Play();
        audioSource2.Pause();
    }



    public void ChangeMusicState()
    {
        if (isAudio1Playing)
        {
            audioSource1.Pause();
            audioSource2.UnPause();
        }
        else
        {
            audioSource1.UnPause();
            audioSource2.Pause();
        }

        isAudio1Playing = !isAudio1Playing;
    }
    
    
}