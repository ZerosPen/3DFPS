using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public SoundLibrary soundEffects;
    public AudioSource soundSource;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void Play2DSound(string soundEffect)
    {
        soundSource.PlayOneShot(soundEffects.GetSoundfxClip(soundEffect));
    }
}
