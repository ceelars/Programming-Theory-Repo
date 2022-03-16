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
            CheckPlayerInput(purpleInput, GameManager.purpleOrbDestroyed);
        }
    }

    //OVERRIDES//
    protected override void DestroySelf()
    {
        StartCoroutine(InputRefractory(GameManager.purpleOrbDestroyed));
        base.DestroySelf();
    }
    protected override void SetColor()
    {
        orbColor = DataManager.GetColor("Purple");
        base.SetColor();
    }
    public override void FindBeatZone()
    {
        beatZone = GameObject.Find("PurpleZone").transform;
    }
}
