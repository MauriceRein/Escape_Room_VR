using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


//this script is attached to the sword. It checks if it collied with its given floor. If so it sets "SetObjectPlacement" to true so that the mauin function 
//GateOpenWithObjects can know which one is true. IF both are true open the door

public class Object1Collider : MonoBehaviour
{
    public GameObject objectPlacementManager;
    public AudioClip placementSound;

    private AudioSource audioSource;
    private XRGrabInteractable xrGrabInteractable;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        xrGrabInteractable = GetComponent<XRGrabInteractable>();
        xrGrabInteractable.onSelectEntered.AddListener(OnGrabbed);
        xrGrabInteractable.onSelectExited.AddListener(OnReleased);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pillar1"))
        {
            PlaySound(placementSound);
            objectPlacementManager.GetComponent<GateOpenWithObjects>().SetObject1Placement(true);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pillar1"))
        {
            objectPlacementManager.GetComponent<GateOpenWithObjects>().SetObject1Placement(false);
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

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        xrGrabInteractable.colliders.ForEach(collider => collider.enabled = false);
    }

    private void OnReleased(XRBaseInteractor interactor)
    {
        xrGrabInteractable.colliders.ForEach(collider => collider.enabled = true);
    }
}
