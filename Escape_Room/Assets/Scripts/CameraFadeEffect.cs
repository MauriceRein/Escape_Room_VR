using System.Collections;
using UnityEngine;

public class CameraFadeEffect : MonoBehaviour
{
    public string floorTag = "Floor";
    public Camera mainCamera; 
    public Camera blackoutCamera; 
    public float DurationofSwitch = 40f; 

    private bool isSwitchActive = false; 
    private float timer = 0f; 

    private void Start()
    {
        //Disable black camera at the start of the game
        blackoutCamera.enabled = false;
    }

    private void Update()
    {
        if (isSwitchActive)
        {
            // Increment the timer
            timer += Time.deltaTime;

            if (timer >= DurationofSwitch)
            {
               //after a cetrain time disable the black camera 
                DisableBlackoutCamera();
                timer = 0f; 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(floorTag))
        {
            
            EnableBlackoutCamera();
        }
    }

    private void EnableBlackoutCamera()
    {
        if (!isSwitchActive)
        {
            //enable black camera -> disable main camera
            mainCamera.enabled = false;
            blackoutCamera.enabled = true;
            isSwitchActive = true;
        }
    }

    private void DisableBlackoutCamera()
    {
        if (isSwitchActive)
        {
             //enable main camera -> disable black camera
            blackoutCamera.enabled = false;
            mainCamera.enabled = true;
            isSwitchActive = false;
        }
    }
}
