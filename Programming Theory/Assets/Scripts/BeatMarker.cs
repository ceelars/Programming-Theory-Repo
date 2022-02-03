using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMarker : MonoBehaviour
{
    public float markerSpeed;
    public Transform beatZone;
    public static bool isInBeatZone, canBeDestroyed;

    private void Awake()
    {
        ScoreManager.activeOrbs.Add(this);
    }
    private void FixedUpdate()
    {
        MoveDown();
        ConstrainMarkerMovement();
        isInBeatZone = false;
    }
    public virtual void MoveDown()
    {
        transform.Translate(Vector3.down * Time.deltaTime * markerSpeed);
    }
    public virtual void ConstrainMarkerMovement()
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
}
