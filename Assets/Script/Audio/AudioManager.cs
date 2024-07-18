using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource ambient;
    private AudioSource sfx;

    private void Awake()
    {
        Instance = this;
        
        ambient = transform.Find("Ambient").GetComponent<AudioSource>();
        sfx = transform.Find("SFX").GetComponent<AudioSource>();
    }
    
    public void PlayAmbient()
    {
        ambient.loop = true;
        ambient.Play();
    }
    
    public void StopAmbient()
    {
        ambient.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfx.clip = clip;
        sfx.loop = false;
        sfx.Play();
    }
}
