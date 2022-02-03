using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundsOnBeat : MonoBehaviour
{
    public MusicManager musicManager;
    public AudioClip whoosh, softStep, loudStep;
    public AudioClip[] piano;
    int randomPiano;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BeatDetector.beatFull)
        {
            musicManager.PlaySound(softStep, 1);
            if (BeatDetector.beatCountFull % 2 == 0)
            {
                randomPiano = Random.Range(0, piano.Length);
            }
        }
        if (BeatDetector.beatD8 && BeatDetector.beatCountD8 % 2 == 0)
        {
            musicManager.PlaySound(softStep, 1);
        }
        if (BeatDetector.beatD8 && (BeatDetector.beatCountD8 % 8 == 2 || BeatDetector.beatCountD8 % 8 == 4))
        {
            musicManager.PlaySound(piano[randomPiano], 1);
        }
    }
}
