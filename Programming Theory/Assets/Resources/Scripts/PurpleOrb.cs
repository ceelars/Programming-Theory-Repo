using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleOrb : BeatMarker
{
    private float specialPurpleDuration = 3.0f;
    private float normalPurpleDuration = 3.0f;
    public KeyCode purpleInput = KeyCode.S;

    protected override void Awake()
    {
        base.Awake();
        SetOrbDuration(normalPurpleDuration, specialPurpleDuration);
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
            CheckPlayerInput(purpleInput);
        }
    }
    
    //OVERRIDES//
    public override void FindBeatZone()
    {
        beatZone = GameObject.Find("PurpleZone").transform;
    }
}
