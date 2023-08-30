using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TeleportationEnd2 : MonoBehaviour
{
    public Transform teleportTarget2; 

    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("FloorEnd")) 
        {
            TeleportPlayer();
        }
    }

    
    private void TeleportPlayer()
    {
        transform.position = teleportTarget2.position; 
    }
}
