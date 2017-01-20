using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour {

    public static ObjectPooling Pooling;
    public GameObject TargetObject;
    public int PoolingNumber;
    List<GameObject> PoolList;
    void awake()
    {
        Pooling = this;
        PoolList = new List<GameObject>();
    }

	void Start () {
		for(int i = 0; i < PoolingNumber; i++)
        {
            GameObject gameObject = GameObject.Instantiate(TargetObject);
            gameObject.SetActive(false);
            PoolList.Add(gameObject);
        }
	}

    public GameObject popObject()
    {
        for(int i = 0; i < PoolList.Count; i++)
        {
            if (!PoolList[i].activeInHierarchy)
            {
                PoolList[i].SetActive(true);
                return PoolList[i];
            }
        }
        return null;
    }
}
