using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleOrb : BeatMarker
{
    private void Awake()
    {
        SetOrbSpeed(2);
        FindBeatZone();
    }
    private void FixedUpdate()
    {
        isInBeatZone = false;
        MoveToZone();
        ConstrainMarkerMovement();
    }

    protected override void FindBeatZone()
    {
        beatZone = GameObject.Find("PurpleZone").transform;
    }
}
