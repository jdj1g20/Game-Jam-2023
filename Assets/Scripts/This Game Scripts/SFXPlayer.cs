using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public AudioClip buttonClick;


    public AudioSource buttonAudio;

  


    public static SFXPlayer sfxInstance;

    private void Awake()
    {
        if (sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sfxInstance = this;
        DontDestroyOnLoad(this);
    }

    public void playButtonSFX()
    {
        buttonAudio.clip = buttonClick;
        buttonAudio.Play();
    }

    
}