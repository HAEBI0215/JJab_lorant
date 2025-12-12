using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip fireClip;
    public AudioClip reloadClip;
    public AudioClip detectedClip;
    public AudioClip hitClip;

    public void PlaySound()
    {
        audioSource.PlayOneShot(fireClip, 0.5f);
    }

    public void ReloadSound()
    {
        audioSource.PlayOneShot(reloadClip, 0.5f);
    }

    public void DetectSound()
    {
        audioSource.PlayOneShot(detectedClip, 0.5f);
    }

    public void HitSound()
    {
        audioSource.PlayOneShot(hitClip, 0.5f);
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
