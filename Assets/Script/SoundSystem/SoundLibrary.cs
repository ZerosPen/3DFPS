using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SoundFXlibrary
{
    public string groupID;
    public AudioClip[] clips;
}
public class SoundLibrary : MonoBehaviour
{
    public SoundFXlibrary[] Soundfxlibrary;

    public AudioClip GetSoundfxClip(string name)
    {
        foreach (var soundfx  in Soundfxlibrary)
        {
            if (soundfx.groupID == name)
            {
                return soundfx.clips[Random.Range(0, soundfx.clips.Length)];
            }
        }
        return null;
    }
}
