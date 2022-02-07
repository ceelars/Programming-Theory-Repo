using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrb : BeatMarker
{
    private void Awake()
    {
        FindBeatZone();
        SetOrbSpeed(2);
        SetOrbBaseSpeed();
    }

    private void FixedUpdate()
    {
        isInBeatZone = false;
        MoveToZone();
        ConstrainMarkerMovement();
    }
    
    protected override void ConstrainMarkerMovement()
    {
        base.ConstrainMarkerMovement();
        if(transform.position.x >= beatZone.position.x)
        {
            transform.position = beatZone.position;
        }
    }

    protected override void FindBeatZone()
    {
        beatZone = GameObject.Find("GreenZone").transform;
    }
}
