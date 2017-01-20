using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {
    public float velocity = 5f;
    private float lifeTime = 3f;
	void Start () {
        
	}

    IEnumerator delayDestory(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("set false");
        this.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        StartCoroutine(delayDestory(lifeTime));
    }
	
	void Update () {
        this.transform.position = this.transform.position + this.transform.forward * velocity * Time.deltaTime;
	}
}
