using UnityEngine;

//source : https://www.youtube.com/watch?v=tXhW3OoMjMY&t=235s

public class KeyFeedBack : MonoBehaviour
{
    public AudioClip beepSoundClip;
    private AudioSource audioSource;
    private Renderer buttonRenderer;

    private Color originalColor;
    public bool keyHit = false;

    // Timer to return the color
    private float colorReturnTime = 0.5f;
    private float returnColor;

    private void Start()
    {
        
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1;
        audioSource.volume = 0.1f;
        buttonRenderer = GetComponent<Renderer>();
        originalColor = buttonRenderer.material.color;

        // Set the audio clip
        audioSource.clip = beepSoundClip;
    }

    void Update()
    {
        if (keyHit && returnColor < Time.time)
        {
            audioSource.PlayOneShot(beepSoundClip);
            returnColor = Time.time + colorReturnTime;
            buttonRenderer.material.color = Color.green;
            keyHit = false;
        }
        if (buttonRenderer.material.color != originalColor && returnColor < Time.time)
        {
            buttonRenderer.material.color = originalColor;
        }
    }
}
