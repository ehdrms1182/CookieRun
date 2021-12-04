using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource Sound;

    public AudioClip eattingSound;

    private void Start()
    {
        Sound = GetComponent<AudioSource>();
    }

    public void PlayEattingSound()
    {
        Sound.PlayOneShot(eattingSound);
    }
}
