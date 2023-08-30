using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//we just reused the OnlyTeleport.cs to teleport the position every second to this position for a duration of 40seconds. This is a workarount because we didnt manage to disable the Controls.

public class MovementStop : MonoBehaviour
{
    public Transform teleportTarget; 

     //Every 1 second get ported back to the location
    public float Interval = 1f; 
    // For 40 seconds
    public float Duration = 40f; 

    private bool isActive = false; 

    //If the player collides with the collider, teleport
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TeleportArea")) 
        {
            if (!isActive)
            {
                StartCoroutine(AutoActivationCoroutine());
            }
        }
    }

    
    private IEnumerator AutoActivationCoroutine()
    {
        isActive = true;
        float timer = 0f;

        while (timer < Duration)
        {
            TeleportPlayer();
            yield return new WaitForSeconds(Interval);
            timer += Interval;
        }

        isActive = false;
    }

    // Teleports the player 
    private void TeleportPlayer()
    {
        transform.position = teleportTarget.position; 
    }
}
