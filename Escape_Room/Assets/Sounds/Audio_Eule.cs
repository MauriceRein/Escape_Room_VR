using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Eule : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!source.isPlaying && clip != null)
            {
                source.PlayOneShot(clip);
            }
        }
    }
}
