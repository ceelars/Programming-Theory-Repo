using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleOrb : BeatMarker
{
    private void Awake()
    {
        FindBeatZone();
        SetOrbDuration(3);
        SetOrbBaseSpeed();
    }
    private void FixedUpdate()
    {
        isInBeatZone = false;
        MoveToZone();
        ConstrainMarkerMovement();
    }

    public override void FindBeatZone()
    {
        beatZone = GameObject.Find("PurpleZone").transform;
    }
    
}
