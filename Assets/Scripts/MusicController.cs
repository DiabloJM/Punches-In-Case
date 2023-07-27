using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPaused = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeMusicState()
    {
        if (isPaused)
        {
            audioSource.UnPause();
        }
        else
        {
            audioSource.Pause();
        }

        isPaused = !isPaused;
    }
    
    
}