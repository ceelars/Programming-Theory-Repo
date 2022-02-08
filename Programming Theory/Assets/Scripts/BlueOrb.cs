using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueOrb : BeatMarker
{
    public GameObject specialOrb;
    private void Awake()
    {
        FindBeatZone();
        CheckChildStatus();
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
        if(transform.position.x <= beatZone.position.x)
        {
            transform.position = beatZone.position;
            if (gameObject.transform.parent != specialOrb.transform)
            {
                base.ConstrainMarkerMovement();
            }
        }
    }
    public override void FindBeatZone()
    {
        beatZone = GameObject.Find("BlueZone").transform;
    }
    private void CheckChildStatus()
    {
        if (gameObject.transform.parent == specialOrb.transform)
        {
            SetOrbDuration(0.5f);
        }
        else
            SetOrbDuration(2.0f);
    }
}
