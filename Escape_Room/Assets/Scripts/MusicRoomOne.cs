
using UnityEngine;

public class MusicRoomOne : MonoBehaviour
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
        if (collider.CompareTag("FloorTelephone")) 
        {
            PlayMusic(music);
        }
        
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("MusicTwo")) 
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


