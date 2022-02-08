using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMarker : MonoBehaviour
{
    public bool isInBeatZone, canBeDestroyed;

    public Transform beatZone;
    private float orbSpeed;
    public float orbDuration;
    protected float OrbDuration
    {
        get { return orbDuration; }
        set
        {
            if (value <= 0)
            {
                Debug.LogError("Duration must have a positive value");
            }
            else
            {
                orbDuration = value;
            }

        }
    }

    public void SetOrbBaseSpeed()
    {
        float distance = Vector3.Distance(beatZone.position, transform.position);
        float duration = (orbDuration * BeatDetector.beatInterval);
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
    protected void SetOrbDuration(float duration)
    {
        orbDuration = duration;
    }
    public virtual void FindBeatZone()
    {
        beatZone = GameObject.FindGameObjectWithTag("BeatZone").transform;
    }
    public virtual void DestroySelf()
    {
        if (canBeDestroyed)
        {
            Destroy(this.gameObject);
        }
    }
}
