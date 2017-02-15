using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleMovement : ObjectMovement {
    public override void OnUpdateMovement()
    {
        pos += transform.forward * Time.deltaTime * velocity;
        Bullet.transform.position = pos + transform.right * Mathf.Sin(Time.time * frequency) * magnitute;
    }

    // Use this for initialization
    void Start () {
		
	}
}
