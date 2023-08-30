using UnityEngine;


//if the player crosses a specific floor, and the audio hasnt been played before. Play the audio!

public class PhoneRinging : MonoBehaviour
{
    public AudioClip audioFile;
    private bool hasPlayedAudio = false;


    private void OnTriggerEnter(Collider other)
    {
        if ( !hasPlayedAudio && other.CompareTag("FloorTelephone") )
        {
            AudioSource.PlayClipAtPoint(audioFile, transform.position);
            hasPlayedAudio = true;
        }
    }

   
}
