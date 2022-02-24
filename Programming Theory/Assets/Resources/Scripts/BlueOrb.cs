using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueOrb : BeatMarker
{
    private float specialBlueDuration = 0.5f;
    private float normalBlueDuration = 2.0f;
    public KeyCode blueInput = KeyCode.A;

    protected override void Awake()
    {
        base.Awake();
        SetOrbDuration(normalBlueDuration, specialBlueDuration);
        SetOrbBaseSpeed();
    }
    private void Update()
    {
        RunDuringGame();
    }
    
    //SCRIPTS TO RUN WHILE GAME IS ACTIVE//
    void RunDuringGame()
    {
        if (GameManager.isGameActive)
        {
            CheckPlayerInput(blueInput);
        }
    }
    protected override void ConstrainMarkerMovement()
    {
        if (transform.position.x <= beatZone.position.x)
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

   
}
