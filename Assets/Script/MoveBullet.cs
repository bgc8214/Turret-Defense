using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

    public GameObject Muzzle;
    public GameObject Bullet;
    public GameObject Explosion;


    public float velocity = 5f;
    private float lifeTime = 3f;
	void Start () {
       
    }

    IEnumerator InActiveObjectDelay(float delay, GameObject obj)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }

    IEnumerator InActiveSelf(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        Muzzle.SetActive(true);

        Bullet.SetActive(true);
        Muzzle.transform.position = this.transform.position;
        Muzzle.transform.rotation = this.transform.rotation;
        Bullet.transform.position = this.transform.position;
        Bullet.transform.rotation = this.transform.rotation;

        StartCoroutine(InActiveObjectDelay(lifeTime, Muzzle));
        StartCoroutine(InActiveObjectDelay(3, Bullet));
        StartCoroutine(InActiveSelf(lifeTime));
    }
	
	void Update () {
        Bullet.transform.position = Bullet.transform.position + Bullet.transform.forward * velocity * Time.deltaTime;
	}
}
