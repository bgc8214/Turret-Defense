using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : ObjectMovement
{
    public override void OnUpdateMovement()
    {
        line.numPositions = 2;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, Enemy.position);
        
    }

    private LineRenderer line;
    // Use this for initialization
    void Start () {
         line =GetComponent<LineRenderer>();
	}
	
}
