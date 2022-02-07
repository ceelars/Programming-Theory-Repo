using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundsOnBeat : MonoBehaviour
{
    public MusicManager musicManager;
    public AudioClip whoosh/*, softStep, loudStep*/;
    public AudioClip[] piano;
    int randomPiano;

    // Update is called once per frame
    void Update()
    {
        //PlayOnSecondFullBeat();
        PlayOnEveryFullBeat();
        //PlayOnEveryQuarterBeat();
        //PlayOnQuarterAndHalfBeat();
        //ChangePianoNote();
    }
    void PlayOnSecondFullBeat()
    {
        if (BeatDetector.beatFull && BeatDetector.beatCountFull % 2 == 0)
        {
            //PlayClip(loudStep, 1);
        }
    }
    void PlayOnEveryFullBeat()
    {
        if (BeatDetector.beatFull)
        {
            PlayClip(whoosh, 1);
        }
    }
    void PlayOnEveryQuarterBeat()
    {
        if (BeatDetector.beatD8 && BeatDetector.beatCountD8 % 2 == 0)
        {
            //PlayClip(softStep, 1);
        }
    }
    void PlayOnQuarterAndHalfBeat()
    {
        if (BeatDetector.beatD8 && (BeatDetector.beatCountD8 % 8 == 2 || BeatDetector.beatCountD8 % 8 == 4))
        {
            PlayRandomPiano();
        }
        
    }
    void ChangePianoNote()
    {
        if (BeatDetector.beatFull && BeatDetector.beatCountFull % 2 == 0)
        {
            randomPiano = Random.Range(0, piano.Length);
        }
    }
    void PlayRandomPiano()
    {
        musicManager.PlaySound(piano[randomPiano], 1);
    }
    void PlayClip(AudioClip clip, float volume)
    {
        musicManager.PlaySound(clip, volume);
    }
    
}
