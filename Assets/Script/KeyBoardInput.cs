using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardInput : MonoBehaviour {

    static int a = 0;
    public static ObjectPooling.Type type;
    public static GameObject[] tiles;
    bool[] hasTurret = new bool[16];

    public void OnClickLeft()
    {
        if (a == 0)
            a = 15;
        a--;
        tiles[a].GetComponent<Renderer>().material.color = Color.blue;
        Debug.Log(a);
    }

    public void OnClickRight()
    {
        if (a == 15)
            a = -1;
        a++;
        tiles[a].GetComponent<Renderer>().material.color = Color.red;
        Debug.Log(a);
    }

    public void OnClickUp()
    {
        if (a < 4)
            a += 16;
        a -= 4;
        tiles[a].GetComponent<Renderer>().material.color = Color.blue;
        Debug.Log(a);
    }

    public void OnClickDown()
    {
        if (a > 11)
            a -= 16;
        a += 4;
        tiles[a].GetComponent<Renderer>().material.color = Color.gray;
        Debug.Log(a);
    }
        
    public void OnClickEnter()
    {
        if (hasTurret[a] == false) 
            TurretManager.Instance.GenerateTurretByIndex(a, type);
        hasTurret[a] = true;
        transform.parent.parent.GetComponent<UIPanel>().alpha = 0;
        transform.root.FindChild("TurretPanel").GetComponent<UIPanel>().alpha = 1;
    }
}
