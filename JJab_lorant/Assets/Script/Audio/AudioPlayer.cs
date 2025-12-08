using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class AudioPlayer : MonoBehaviour
{
    PlayerManager pm;
    public AudioSource audioSource;
    public AudioClip fireClip;

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerManager>();
    }

    public void PlaySound()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(fireClip, 0.5f);
        }
        else
        {
            audioSource.Stop();
            return;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
