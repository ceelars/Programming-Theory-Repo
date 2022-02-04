using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMarker : MonoBehaviour
{
    public static bool isInBeatZone, canBeDestroyed;

    protected Transform beatZone;
    private float markerSpeed;
    protected float MarkerSpeed
    {
        get { return markerSpeed; }
        set
        {
            if (value <= 0)
            {
                Debug.LogError("Speed must have a positive value");
            }
            else
            {
                markerSpeed = value;
            }

        }
    }

    private void Awake()
    {
    }
    private void FixedUpdate()
    {
        MoveToZone();
        ConstrainMarkerMovement();
        isInBeatZone = false;
    }
    private void MoveToZone()
    {
        Vector3 direction = beatZone.position - transform.position;
        transform.Translate(direction.normalized * Time.deltaTime * markerSpeed);
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
    public void DestroySelf()
    {
        if (canBeDestroyed)
        {
            Destroy(gameObject);
        }
    }
    
    protected void SetMarkerSpeed(float speed)
    {
        MarkerSpeed = BeatDetector.bpm / 60;
        MarkerSpeed *= speed;
    }
    protected virtual void FindBeatZone()
    {
        beatZone = GameObject.FindGameObjectWithTag("BeatZone").transform;
    }
    
}
