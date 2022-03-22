using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrb : BeatMarker
{
    private float specialGreenDuration = 0.5f;
    private float normalGreenDuration = 2.0f;
    public KeyCode greenInput = KeyCode.D;

    protected override void Awake()
    {
        base.Awake();
        SetOrbDuration(normalGreenDuration, specialGreenDuration);
        SetOrbBaseSpeed();
    }
    private void Update()
    {
        RunDuringGame();
    }

    //SCRIPTS TO RUN WHILE GAME IS ACTIVE//
    private void RunDuringGame()
    {
        if (GameManager.isGameActive)
        {
            CheckPlayerInput(greenInput, GameManager.greenOrbDestroyed);
        }
        else if (MenuUIHandler.isInMenuStatic)
        {
            CheckMiss();
        }
    }

    protected override void DestroySelf()
    {
        StartCoroutine(InputRefractory(GameManager.greenOrbDestroyed));
        base.DestroySelf();
    }
    protected override void SetColor()
    {
        orbColor = DataManager.GetColor("Green");
        base.SetColor();
    }

    protected override void ConstrainMarkerMovement()
    {
        if (transform.position.x >= beatZone.position.x)
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
        beatZone = GameObject.Find("GreenZone").transform;
    }

}
