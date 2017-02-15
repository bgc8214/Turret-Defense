using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : BaseManager<TurretManager>
{
    public UIPanel panel;
    public GameObject[] tiles;
    int index = 0;
    public override void OnAwake()
    {

    }


    public void OnClickButton()
    {
        //panel.alpha = 0f;
        ObjectPooling.Instance.GenerateObject(ObjectPooling.Type.BulletTurret, tiles[index].transform.position, Quaternion.identity);
        index++;
    }

    public void GenerateTurret(ObjectPooling.Type type, Vector3 position, Quaternion lotation)
    {
        ObjectPooling.Instance.GenerateObject(type, position, lotation);
    }

}
