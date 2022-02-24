using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialOrb : BeatMarker
{
    public GameObject blueOrbChild, greenOrbChild;
    private float specialDuration = 3.0f;
    private float normalDuration = 3.0f;
    public KeyCode specialInput = KeyCode.S;
    private GameObject blueOrb, greenOrb, purpleOrb;
    private SphereCollider blueOrbCollider, greenOrbCollider, purpleOrbCollider;
    private GreenOrb greenOrbScript;
    private BlueOrb blueOrbScript;
    private PurpleOrb purpleOrbScript;

    protected override void Awake()
    {
        base.Awake();
        SetOrbDuration(normalDuration, specialDuration);
        SetOrbBaseSpeed();
        InitializeChildren();
        DisableChildScripts();
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
            CheckPlayerInput(specialInput);
        }
    }
   
    
    
    //OVERRIDES//
    public override void FindBeatZone()
    {
        beatZone = GameObject.Find("PurpleZone").transform;
    }

    protected override void DestroySelf()
    {
        int activeChildObjects = gameObject.transform.childCount;

        if (canBeDestroyed && activeChildObjects != 0)
        {
            EnableChildScripts();
            EnableColliders();
            Destroy(purpleOrb);
            transform.DetachChildren();
            StartCoroutine("DestroyDelay");
        }
    }
    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }

    private void InitializeChildren()
    {
        purpleOrb = transform.Find("PurpleOrb").gameObject;
        blueOrb = transform.Find("BlueOrb").gameObject;
        greenOrb = transform.Find("GreenOrb").gameObject;

        purpleOrbScript = purpleOrb.GetComponent<PurpleOrb>();
        blueOrbScript = blueOrb.GetComponent<BlueOrb>();
        greenOrbScript = greenOrb.GetComponent<GreenOrb>();

        purpleOrbCollider = purpleOrb.GetComponent<SphereCollider>();
        blueOrbCollider = blueOrb.GetComponent<SphereCollider>();
        greenOrbCollider = greenOrb.GetComponent<SphereCollider>();

        DisableColliders();
        DisableChildScripts();

    }

    //Turn child scripts off
    private void DisableChildScripts()
    {
        purpleOrbScript.enabled = false;
        blueOrbScript.enabled = false;
        greenOrbScript.enabled = false;
    }

    //Turn child scripts on
    private void EnableChildScripts()
    {
        purpleOrbScript.enabled = true;
        blueOrbScript.enabled = true;
        greenOrbScript.enabled = true;

        purpleOrbScript.FindBeatZone();
        blueOrbScript.FindBeatZone();
        blueOrbScript.SetOrbBaseSpeed();
        greenOrbScript.FindBeatZone();
        greenOrbScript.SetOrbBaseSpeed();
    }
    private void DisableColliders()
    {
        purpleOrbCollider.enabled = false;
        blueOrbCollider.enabled = false;
        greenOrbCollider.enabled = false;
    }
    private void EnableColliders()
    {
        purpleOrbCollider.enabled = true;
        blueOrbCollider.enabled = true;
        greenOrbCollider.enabled = true;
        
    }
}
