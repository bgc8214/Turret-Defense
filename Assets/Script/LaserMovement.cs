using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : ObjectMovement
{
    public override void OnUpdateMovement()
    {
        Bullet.transform.position = Bullet.transform.position + Bullet.transform.forward * velocity * Time.deltaTime;
    }

    // Use this for initialization
    void Start () {
		
	}
	
}
