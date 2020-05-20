using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    public List<AudioClip> sounds;
    public AudioSource audioSource;

    public void PlayAudio(int audio)
    {
        audioSource.PlayOneShot(sounds[audio]);
    }
}
