using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : BaseManager<TurretManager>
{
    public UIPanel TurretPanel;
    public UIPanel KeyBoardPanel;
    public GameObject[] tiles;
    int index = 0;
    public override void OnAwake()
    {

    }

    public void OnClickButton(ObjectPooling.Type type)
    {
        KeyBoardInput.type = type;
        KeyBoardInput.tiles = tiles;
        TurretPanel.alpha = 0;
        KeyBoardPanel.alpha = 1;
    }
    
    public void GenerateTurretByIndex(int index, ObjectPooling.Type type)
    {
        ObjectPooling.Instance.GenerateObject(type, tiles[index].transform.position, Quaternion.identity);
        
    }

    public void GenerateTurret(ObjectPooling.Type type, Vector3 position, Quaternion lotation)
    {
        ObjectPooling.Instance.GenerateObject(type, position, lotation);
    }

}
