using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardInput : MonoBehaviour {

    public static int TileIndex = 0;
    public static ObjectPooling.Type type;
    public static GameObject[] tiles;
    bool[] hasTurret = new bool[16];

    public void OnClickLeft()
    {
        if (TileIndex == 0)
            TileIndex = 15;
        TileIndex--;
        tileColorChange();
        tiles[TileIndex].GetComponent<Renderer>().material.color = Color.gray;
    }

    public void OnClickRight()
    {
        if (TileIndex == 15)
            TileIndex = -1;
        TileIndex++;
        tileColorChange();
        tiles[TileIndex].GetComponent<Renderer>().material.color = Color.gray;
    }

    public void OnClickUp()
    {
        if (TileIndex < 4)
            TileIndex += 16;
        TileIndex -= 4;
        tileColorChange();
        tiles[TileIndex].GetComponent<Renderer>().material.color = Color.gray;
    }

    public void OnClickDown()
    {
        if (TileIndex > 11)
            TileIndex -= 16;
        TileIndex += 4;
        tileColorChange();
        tiles[TileIndex].GetComponent<Renderer>().material.color = Color.gray;
    }
        
    public void OnClickEnter()
    {
        tileColorChange();
        if (hasTurret[TileIndex] == false) 
            TurretManager.Instance.GenerateTurretByIndex(TileIndex, type);
        hasTurret[TileIndex] = true;
        transform.parent.parent.GetComponent<UIPanel>().alpha = 0;
        transform.root.FindChild("TurretPanel").GetComponent<UIPanel>().alpha = 1;
    }

    void tileColorChange()
    {
        for (int i = 0; i < 16; i++)
        {
            tiles[i].GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
