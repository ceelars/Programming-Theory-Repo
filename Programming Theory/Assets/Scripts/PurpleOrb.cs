using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleOrb : BeatMarker
{
    private void Start()
    {
        FindBeatZone();
    }
    private void Awake()
    {
        AddToActiveOrbs();
        SetMarkerSpeed(2);
    }
    protected override void FindBeatZone()
    {
        beatZone = GameObject.Find("PurpleZone").transform;
    }
}
