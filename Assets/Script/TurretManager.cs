using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : BaseManager<TurretManager>
{
    public override void OnAwake()
    {

    }

    void GenerateTurret(ObjectPooling.Type type, Vector3 position, Quaternion lotation)
    {
        ObjectPooling.Instance.GenerateObject(type, position, lotation);
    }

    void Start()
    {
        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        yield return new WaitForSeconds(2.0f);
        GenerateTurret(ObjectPooling.Type.BulletTurret, Vector3.zero, Quaternion.identity);
    }

    void Update()
    {

    }
}
