using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {
    public float velocity = 5f;
    private float lifeTime = 3f;
	void Start () {
        StartCoroutine(delayDestory(lifeTime));
	}

    IEnumerator delayDestory(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject.Destroy(this.gameObject);
    }
	
	void Update () {
        this.transform.position = this.transform.position + this.transform.forward * velocity * Time.deltaTime;
	}
}
