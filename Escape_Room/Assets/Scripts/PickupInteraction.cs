using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;


public class PickupInteraction : XRGrabInteractable
{

    
    [SerializeField] private TextMeshProUGUI inventoryText;

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        //if picked up
        base.OnSelectEntered(interactor);

        //remove the component
        gameObject.SetActive(false);

        //update text
        inventoryText.text = "Smartphone wurde zum Inventar hinzugefügt. Du kannst jetzt Telefonieren!";
    }
}