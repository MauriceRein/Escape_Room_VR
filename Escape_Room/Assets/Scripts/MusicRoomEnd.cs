


using UnityEngine;

public class MusicRoomEnd : MonoBehaviour
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
        if (collider.CompareTag("FloorEnd")) 
        {
            PlayMusic(music);
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

}


