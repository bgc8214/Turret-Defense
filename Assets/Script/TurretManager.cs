using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : BaseManager<TurretManager>
{
    public Camera camera;
    public UIPanel TurretPanel;
    public UIPanel KeyBoardPanel;
    public GameObject[] tiles;
    ObjectPooling.Type type;
    public override void OnAwake()
    {

    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(hit.collider.gameObject.name);
                GenerateTurret(type, hit.collider.gameObject.transform.position, hit.collider.gameObject.transform.rotation);
                TurretPanel.alpha = 1;
                KeyBoardPanel.alpha = 0;
            }
        }
    }

    public void OnClickButton(ObjectPooling.Type type)
    {
        this.type = type;
        KeyBoardInput.type = type;
        KeyBoardInput.tiles = tiles;
        TurretPanel.alpha = 0;
        KeyBoardPanel.alpha = 1;
        tiles[KeyBoardInput.TileIndex].GetComponent<Renderer>().material.color = Color.gray;
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
