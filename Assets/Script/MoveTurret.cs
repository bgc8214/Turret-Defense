using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTurret : MonoBehaviour {
    public Transform Head;
    public Transform Shooter;
    public Transform Enemy;
    public float ShootingDelay;
    public ObjectPooling.Type MissileType;
    Coroutine cor;
    void Start () {
        cor = StartCoroutine(shootBullet());
    }
    int tick = 0;
    IEnumerator shootBullet()
    {
        for(;;)
        {
            // flag 로 타겟을 찾는 것도 좋음
            yield return new WaitForSeconds(ShootingDelay);
            //   GameObject newBullet = GameObject.Instantiate(bullet); 만들떄
            GameObject newBullet = ObjectPooling.Instance.GenerateObject(MissileType, Shooter.position, Shooter.rotation);
            if (newBullet == null)
            {
                continue;
            }
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
