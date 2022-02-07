using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatDetector : MonoBehaviour
{
    private static BeatDetector beatDetectorInstance;
    private float beatTimer, beatTimerD8;
    
    public static float beatInterval, beatIntervalD8;
    public static bool beatFull, beatD8;
    public static int beatCountFull, beatCountD8;
    public static float bpm = 60;
 
    /*public float BPM
    {
        get { return bpm; }
        private set { bpm = value; }
    }*/

    //Ensures this is the only instance of beat detector
    private void Awake()
    {
        if(beatDetectorInstance != null && beatDetectorInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            beatDetectorInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {
        BeatDetection();
    }
    void BeatDetection()
    {
        //full beat count
        beatFull = false;
        beatInterval = 60 / bpm;
        beatTimer += Time.deltaTime;
        if (beatTimer >= beatInterval)
        {
            beatTimer -= beatInterval;
            beatFull = true;
            beatCountFull++;
        }

        //8th beat count
        beatD8 = false;
        beatIntervalD8 = beatInterval / 8;
        beatTimerD8 += Time.deltaTime;
        if (beatTimerD8 >= beatIntervalD8)
        {
            beatTimerD8 -= beatIntervalD8;
            beatD8 = true;
            beatCountD8++;
        }
    }
}
