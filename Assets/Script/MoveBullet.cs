using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

    public GameObject Muzzle;
    public GameObject Bullet;
    public GameObject Explosion;
    public ObjectPooling.Type MissileType;

    public float velocity = 5f;
    private float lifeTime = 3f;
    public float magnitute = 0.5f;
    public float frequency = 20.0f;
    Vector3 pos;

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

        pos = this.transform.position;

        StartCoroutine(InActiveObjectDelay(1, Muzzle));
        StartCoroutine(InActiveObjectDelay(2, Bullet));
        StartCoroutine(InActiveSelf(lifeTime));
    }
	
	void Update () {
        if (MissileType == ObjectPooling.Type.Missile)
        {
            pos += transform.forward * Time.deltaTime * velocity;
            Bullet.transform.position = pos + transform.right * Mathf.Sin(Time.time * frequency) * magnitute;
        }
        else if (MissileType == ObjectPooling.Type.Bullet)
        {
            Bullet.transform.position = Bullet.transform.position + Bullet.transform.forward * velocity * Time.deltaTime;
        }
	}
}
