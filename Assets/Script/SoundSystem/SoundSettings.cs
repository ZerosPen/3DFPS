using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider SoundfxSlider;

    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("VolumeMusic", volume);
    }

    public void UpdateSoundFXVolume(float volume)
    {
        audioMixer.SetFloat("VolumeSoundFX", volume);
    }

    public void UpdateMasterVolume(float volume)
    {
        audioMixer.SetFloat("VolumeMaster", volume);
    }

}
