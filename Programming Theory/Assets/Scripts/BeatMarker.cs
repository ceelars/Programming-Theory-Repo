using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMarker : MonoBehaviour
{
    public bool isInBeatZone, canBeDestroyed;

    protected Transform beatZone;
    private float orbSpeed;
    protected float OrbSpeed
    {
        get { return orbSpeed; }
        set
        {
            if (value <= 0)
            {
                Debug.LogError("Speed must have a positive value");
            }
            else
            {
                orbSpeed = value;
            }

        }
    }

    protected void MoveToZone()
    {
        Vector3 direction = beatZone.position - transform.position;
        transform.Translate(direction.normalized * Time.deltaTime * OrbSpeed);
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
    protected void SetOrbSpeed(float speed)
    {
        OrbSpeed = BeatDetector.bpm / 60;
        OrbSpeed *= speed;
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
