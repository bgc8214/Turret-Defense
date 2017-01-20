using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{

    public Transform Target;
    public Transform Head;
    public Transform Shooter;
    public GameObject Bullet;

    void Start()
    {

    }
    int tick = 0;

    void Update()
    {
        var TargetObject = CharacterManager.Instance.nearestCharacter(this.transform.position, 100);
        if(TargetObject != null)
        {
            Target = TargetObject.transform;
            Head.LookAt(Target);
            var shooterLook = Target.position - Shooter.position;
            var headLook = Target.position - Head.position;
            headLook.y = 0;

            Shooter.forward = shooterLook.normalized;
            Head.forward = headLook.normalized;
            Shooter.LookAt(Target.position);

            //Head.rotation.SetLookRotation((Target.position - transform.position).normalized);
            tick++;
            if (tick % 20 == 0)
            {
                var newGo = GameObject.Instantiate(Bullet);
                newGo.SetActive(true);
                newGo.transform.position = Shooter.transform.position;
                newGo.transform.rotation = Shooter.transform.rotation;
            }
        }
        else
        {
            TargetObject = CharacterManager.Instance.nearestCharacter(this.transform.position, 100);
        }
    }
}
