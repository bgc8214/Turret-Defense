using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectMovement : MonoBehaviour {

    public GameObject Muzzle;
    public GameObject Bullet;
    public GameObject Explosion;

    public float velocity = 5f;
    private float lifeTime = 3f;
    public float magnitute = 0.5f;
    public float frequency = 20.0f;
    protected Vector3 pos;

    public Transform Enemy { get; set; }
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

    public abstract void OnUpdateMovement();
	
	void Update () {
        this.transform.LookAt(Enemy);
        OnUpdateMovement();
	}

    void OnCollisionEnter(Collision col)
    {
        //col.contacts[0].point;
        if (col.collider.CompareTag("Enemy"))
        {
            Bullet.SetActive(false);
            Muzzle.SetActive(false);
        }
    }
}
