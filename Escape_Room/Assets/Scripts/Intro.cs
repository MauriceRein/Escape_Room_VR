using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component
    public Collider floorCollider; // Reference to the specific floor collider

    private bool hasTriggeredIntro = false; // Flag to track if the intro has already been triggered

    private void OnTriggerEnter(Collider other)
    {
        if (other == floorCollider && !hasTriggeredIntro)
        {
            PlayIntroScene();
        }
    }

    private void PlayIntroScene()
    {

        // Play the intro video
        videoPlayer.Play();

        // Set the flag to prevent the intro from being triggered multiple times
        hasTriggeredIntro = true;
    }
}