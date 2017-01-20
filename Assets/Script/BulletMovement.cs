using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    public float velocity = 5f;
    private float lifeTime = 5f;
	void Start () {
        //colier
        //time
        StartCoroutine(delayDestory(lifeTime));

        //StopCorutine;
	}

    IEnumerator delayDestory(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject.Destroy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = this.transform.position + this.transform.forward * velocity * Time.deltaTime;
	}
}
