using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : ObjectMovement
{
    public override void OnUpdateMovement()
    {
        Bullet.transform.position = Bullet.transform.position + Bullet.transform.forward * velocity * Time.deltaTime;
    }

    void Start () {
		
	}
}
