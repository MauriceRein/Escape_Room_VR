using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//teleport the player after 15 minutes to the "bad ending"

public class TeleportAfterTime : MonoBehaviour
{
    public Transform teleportTarget;

    private void Start()
    {
        
        Invoke("TeleportPlayer", 960f);
    }

    private void TeleportPlayer()
    {
        transform.position = teleportTarget.position;
    }
}
