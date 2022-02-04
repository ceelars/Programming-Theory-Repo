using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueOrb : BeatMarker
{
    private void Start()
    {
        FindBeatZone();
    }
    private void Awake()
    {
        AddToActiveOrbs();
        SetMarkerSpeed(5);
    }
    protected override void ConstrainMarkerMovement()
    {
        base.ConstrainMarkerMovement();
        if(transform.position.x <= beatZone.position.x)
        {
            transform.position = beatZone.position;
        }
    }
    protected override void FindBeatZone()
    {
        beatZone = GameObject.Find("BlueZone").transform;
    }
}
