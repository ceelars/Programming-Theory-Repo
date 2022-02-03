using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrb : BeatMarker
{
    // Start is called before the first frame update
    public override void MoveDown() 
    {
        transform.Translate(Vector3.down * Time.deltaTime * 2* markerSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
