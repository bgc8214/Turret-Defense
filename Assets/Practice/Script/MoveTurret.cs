using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTurret : MonoBehaviour {
    public Transform Head;
    public Transform Shooter;
    public Transform Enemy;
    public GameObject bullet;
    Coroutine cor;
    void Start () {
        //cor = StartCoroutine(shootBullet());
    }
    int tick = 0;
    IEnumerator shootBullet()
    {
        for(;;)
        {
            // flag 로 타겟을 찾는 것도 좋음
            yield return new WaitForSeconds(0.5f);
            var newGo = GameObject.Instantiate(bullet);
            newGo.SetActive(true);
            newGo.transform.position = Shooter.position;
            newGo.transform.rotation = Shooter.rotation;
        }
    }

    void Update () {
        var TargetObject = CharacterManager.Instance.nearestCharacter(this.transform.position, 70);
        if (TargetObject != null)
        {
            if (cor==null)
            {
                 cor = StartCoroutine(shootBullet());
            }
            Enemy = TargetObject.transform;
            Head.LookAt(Enemy);
            var headLook = Enemy.position - Head.position;
            var shooterLook = Enemy.position - Shooter.position;
            headLook.y = 0;
            Head.forward = headLook.normalized;
            Shooter.forward = shooterLook.normalized;
            Shooter.LookAt(Enemy);
        }
        else
        {
            if(cor!=null)
                StopCoroutine(cor);
            cor = null;
        }
	}
}
