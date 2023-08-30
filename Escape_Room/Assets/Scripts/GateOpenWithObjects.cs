
using UnityEngine;
using System.Collections;

public class GateOpenWithObjects : MonoBehaviour
{
   
    public GameObject object1;
    public GameObject object2;
    public Animator door;
    public AudioClip beepSoundClip;

    private bool isObject1Placed = false;
    private bool isObject2Placed = false;
    private AudioSource audioSource;

    private void Start()
    {
        //door is closed at the beginning
        door.SetBool("IsOpen", false);
        audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator OpenDoorWithDelay(float delay)
        //delay for the door so that its smooth

{
    yield return new WaitForSeconds(delay);
    door.SetBool("IsOpen", true);
}

private IEnumerator PlayGateSoundWithDelay(float delay)
{
    yield return new WaitForSeconds(delay);
    PlaySound(beepSoundClip);
}

    public void SetObject1Placement(bool isPlaced)
    {
        isObject1Placed = isPlaced;
        CheckPuzzleCompletion();
    }

    public void SetObject2Placement(bool isPlaced)
    {
        isObject2Placed = isPlaced;
        CheckPuzzleCompletion();
    }

    private void CheckPuzzleCompletion()
    {
        if (isObject1Placed && isObject2Placed)
        {
            
            StartCoroutine(OpenDoorWithDelay(1.0f)); 
            StartCoroutine(PlayGateSoundWithDelay(0.5f)); 
            
        }
    }

    private void PlaySound(AudioClip soundClip)
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = soundClip;
        audioSource.Play();
    }
}
