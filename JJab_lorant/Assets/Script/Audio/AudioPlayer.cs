using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip fireClip;
    public AudioClip reloadClip;

    public void PlaySound()
    {
        audioSource.PlayOneShot(fireClip, 0.5f);
    }

    public void ReloadSound()
    {
        audioSource.PlayOneShot(reloadClip, 0.5f);
        Debug.Log("play reloaded");
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
