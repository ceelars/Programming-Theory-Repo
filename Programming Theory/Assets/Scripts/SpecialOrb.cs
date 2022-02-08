using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialOrb : BeatMarker
{
    private void Awake()
    {
        DisableChildScripts();
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
    
    public override void DestroySelf()
    {
        if (canBeDestroyed && gameObject.transform.childCount >= 1)
        {
            EnableChildScripts();
        }
        else if (canBeDestroyed && gameObject.transform.childCount == 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void DisableChildScripts()
    {
        GreenOrb greenOrbScript = GetComponentInChildren<GreenOrb>();
        BlueOrb blueOrbScript = GetComponentInChildren<BlueOrb>();

        greenOrbScript.enabled = false;
        blueOrbScript.enabled = false;
    }
    private void EnableChildScripts()
    {
        GreenOrb greenOrbScript = GetComponentInChildren<GreenOrb>();
        BlueOrb blueOrbScript = GetComponentInChildren<BlueOrb>();

        greenOrbScript.enabled = true;
        blueOrbScript.enabled = true;
        blueOrbScript.FindBeatZone();
        blueOrbScript.SetOrbBaseSpeed();
        greenOrbScript.FindBeatZone();
        greenOrbScript.SetOrbBaseSpeed();
    }
}
