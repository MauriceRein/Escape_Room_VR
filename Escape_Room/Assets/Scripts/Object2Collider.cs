using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//this script is attached to the shield. It checks if it collied with its given floor. If so it sets "SetObjectPlacement" to true so that the mauin function 
//GateOpenWithObjects can know which one is true. IF both are true open the door

public class Object2Collider : MonoBehaviour
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
        if (other.CompareTag("Pillar2"))
        {
            PlaySound(placementSound);
            objectPlacementManager.GetComponent<GateOpenWithObjects>().SetObject2Placement(true);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pillar2"))
        {
            objectPlacementManager.GetComponent<GateOpenWithObjects>().SetObject2Placement(false);
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
