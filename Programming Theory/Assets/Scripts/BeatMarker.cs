using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMarker : MonoBehaviour
{
    public bool isInBeatZone, canBeDestroyed;

    protected Transform beatZone;
    private float orbSpeed, orbBaseDuration = 1.0f;
    private float orbSpeedMultiplier;
    protected float OrbSpeedMultiplier
    {
        get { return orbSpeedMultiplier; }
        set
        {
            if (value <= 0)
            {
                Debug.LogError("Speed must have a positive value");
            }
            else
            {
                orbSpeedMultiplier = value;
            }

        }
    }

    protected void SetOrbBaseSpeed()
    {
        float distance = Vector3.Distance(beatZone.position, transform.position);
        float duration = (orbBaseDuration * BeatDetector.beatInterval) / (OrbSpeedMultiplier);
        orbSpeed = distance / duration;
    } 
    protected void MoveToZone()
    {
        Vector3 direction = beatZone.position - transform.position;
        transform.Translate(direction.normalized * Time.deltaTime * orbSpeed);
    }
    protected virtual void ConstrainMarkerMovement()
    {
        if(transform.position.y <= beatZone.position.y)
        {
            transform.position = beatZone.position;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BeatZone"))
        {
            isInBeatZone = true;
            canBeDestroyed = true;
        }
    }
    protected void SetOrbSpeed(int speed)
    {
        OrbSpeedMultiplier = speed/8;
    }
    protected virtual void FindBeatZone()
    {
        beatZone = GameObject.FindGameObjectWithTag("BeatZone").transform;
    }
    public void DestroySelf()
    {
        if (canBeDestroyed)
        {
            Destroy(this.gameObject);
        }
    }
}
