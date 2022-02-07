using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private int bankSize = 10;
    private List<AudioSource> soundClip;

    void Start()
    {
        CreateSoundClipBank();
    }
    //Initialize list of playable clips
    void CreateSoundClipBank()
    {
        soundClip = new List<AudioSource>();
        for (int i = 0; i < bankSize; i++)
        {
            GameObject soundInstance = new GameObject("sound");
            soundInstance.AddComponent<AudioSource>();
            soundInstance.transform.parent = this.transform;
            soundClip.Add(soundInstance.GetComponent<AudioSource>());
        }
    }

    public void PlaySound(AudioClip clip, float volume)
    {
        //Reassign unused slots from soundclip list
        for (int i = 0; i < soundClip.Count; i++)
        {
            if (!soundClip[i].isPlaying)
            {
                soundClip[i].clip = clip;
                soundClip[i].volume = volume;
                soundClip[i].Play();
                return;
            }
        }
        //Create new sound instance and add to soundclip list if all clips are active   
        GameObject soundInstance = new GameObject("sound");
        soundInstance.AddComponent<AudioSource>();
        soundInstance.transform.parent = this.transform;
        soundInstance.GetComponent<AudioSource>().clip = clip;
        soundInstance.GetComponent<AudioSource>().volume = volume;
        soundInstance.GetComponent<AudioSource>().Play();
        soundClip.Add(soundInstance.GetComponent<AudioSource>());
    }
}

