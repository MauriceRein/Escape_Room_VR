using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//source : https://www.youtube.com/watch?v=tXhW3OoMjMY&t=235s

public class KeyPadControl : MonoBehaviour
{
    public int correctCombination;
    public bool accessGranted = false;

    public AudioClip beepSoundClip;
    private AudioSource audioSource;

    // Reference to the door GameObject
    public Animator door;

    // Start is called before the first frame update
    void Start()
    {
        // Disable the door at the beginning
        door.SetBool("IsOpen",false);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1;
        audioSource.volume = 0.1f;
        audioSource.clip = beepSoundClip;
        
    }

     public void TriggerDoorAnimation()
    {

        audioSource.PlayOneShot(beepSoundClip);
        // Open the door
        door.SetBool("IsOpen",true);
    }

    

    public bool CheckIfCorrect(int combination)
    {
        if (combination == correctCombination)
        {
            accessGranted = true;
            TriggerDoorAnimation(); // Trigger the door animation
            return true;
        }
        return false;
    }
}
