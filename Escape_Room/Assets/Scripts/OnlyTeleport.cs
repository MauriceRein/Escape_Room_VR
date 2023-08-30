using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyTeleport : MonoBehaviour
{
    public Transform teleportTarget; 

    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("TeleportArea")) 
        {
            TeleportPlayer();
        }
    }

    
    private void TeleportPlayer()
    {
        transform.position = teleportTarget.position; 
    }
}