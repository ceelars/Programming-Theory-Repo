using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMarker : MonoBehaviour
{
    public GameObject specialOrb;
    public bool isChild, isInBeatZone, canBeDestroyed, beatAttempt, canAttempt;
    public float orbSpeed;
    [SerializeField] 
    private int perfectPoints, goodPoints, badPoints, missedPoints;
    //private int localBeatCountD8;
    
    protected Transform beatZone;

    private ScoreManager scoreManagerScript;
    private SpawnManager spawnManagerScript;
    
    //orbDuration is measured in beats, not seconds
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

    protected virtual void Awake()
    {
        CheckChildStatus();
        FindBeatZone();
        //AssignPointValues();
        scoreManagerScript = GameObject.Find("DataManager").GetComponent<ScoreManager>();
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        spawnManagerScript.ReassignEmptyOrbSlots(this.gameObject);
        canAttempt = false;
    }
    protected virtual void FixedUpdate()
    {
        MoveToZone();
        ConstrainMarkerMovement();
    }

    //ESTABLISH ORB PARAMETERS//
    public virtual void FindBeatZone()
    {
        beatZone = GameObject.FindGameObjectWithTag("BeatZone").transform;
    }
    protected void SetOrbDuration(float normalDuration, float specialDuration)
    {
        if (isChild)
        {
            OrbDuration = specialDuration;
        }
        else
        {
            OrbDuration = normalDuration;
        }
    }
    public void SetOrbBaseSpeed()
    {
        float distance = Vector3.Distance(beatZone.position, transform.position);
        float duration = (OrbDuration * BeatDetector.beatInterval);
        orbSpeed = distance / duration;
    }
    protected virtual void AssignPointValues()
    {
        perfectPoints = 20;
        goodPoints = 10;
        badPoints = 5;
        missedPoints = 5;
    }
    private void CheckChildStatus()
    {
        if (gameObject.transform.parent == specialOrb.transform)
        {
            
            isChild = true;
        }
        else
            isChild = false;

    }

    //CONTROL ORB MOVEMENT//
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

    //RESOLVE ORB OUTCOMES//
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BeatZone"))
        {
            isInBeatZone = true;
        }
        if (other.gameObject.CompareTag("ActiveZone"))
        {
            canAttempt = true;
            canBeDestroyed = true;
        }
        
    }
    protected void CheckPlayerInput(KeyCode playerInput)
    {

        if (Input.GetKeyDown(playerInput))
        {
            CheckAttempt();
        }
        else
        {
            CheckMiss();
        }
    }
    protected virtual void DestroySelf()
    {
        if (canBeDestroyed)
        {
            Destroy(this.gameObject);
        }
        
    }
    /*RESOLVE ATTEMPTS AT HITTING BEAT*/
    public void CheckAttempt()
    {
        int localBeatCountD8 = BeatDetector.beatCountD8 + ((int)(OrbDuration * 8));

        if (isInBeatZone && canAttempt && (localBeatCountD8 % 8 == 7 || localBeatCountD8 % 8 == 0))
        {
            scoreManagerScript.HitPerfectBeat(perfectPoints);
            beatAttempt = true;
            canAttempt = false;
            DestroySelf();
        }
        else if (isInBeatZone && canAttempt && (localBeatCountD8 % 8 == 6 || localBeatCountD8 % 8 == 1))
        {
            scoreManagerScript.HitGoodBeat(goodPoints);
            beatAttempt = true;
            canAttempt = false;
            DestroySelf();
        }
        else if (!isInBeatZone && canAttempt && (localBeatCountD8 % 8 <= 5 || localBeatCountD8 % 8 >= 2))
        {
            scoreManagerScript.HitBadBeat(badPoints);
            beatAttempt = true;
            canAttempt = false;
            DestroySelf();
        }
    }
    /*RESOLVE WHETHER BEAT WAS MISSED OR NOT*/
    public void CheckMiss()
    {
        int localBeatCountD8 = BeatDetector.beatCountD8 + ((int)(OrbDuration * 8));

        if (!beatAttempt && isInBeatZone && localBeatCountD8 % 8 == 2 && BeatDetector.beatD8)
        {
            scoreManagerScript.HitMissedBeat(missedPoints);
            canAttempt = false;
            DestroySelf();
        }
    }
    
}
