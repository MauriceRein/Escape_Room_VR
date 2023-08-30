
using UnityEngine;

public class MusicRoom3 : MonoBehaviour
{
    public AudioClip music;
    private bool hasPlayedAudio = false;
    private AudioSource audiosourcemusic;

    private void Start()
    {
        audiosourcemusic = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("MusicThree")) 
        {
            PlayMusic(music);
        }
        
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("FloorEnd")) 
        {
            StopMusic(music);
        }
    }

    private void PlayMusic(AudioClip soundClip)
    {
        if (!hasPlayedAudio)
        {
            if (audiosourcemusic == null)
        {
            audiosourcemusic = gameObject.AddComponent<AudioSource>();
        }
        hasPlayedAudio = true;
        audiosourcemusic.clip = soundClip;
        audiosourcemusic.Play();
        }
    }
     private void StopMusic(AudioClip soundClip)
    {
        if (hasPlayedAudio)
        {
            audiosourcemusic.Stop();
            hasPlayedAudio = false;
        }
    }

}


