using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour {

    public static ObjectPooling Instance;
    public GameObject TargetObject;
    public int PoolingNumber;
    List<GameObject> PoolList;
    void Awake()
    {
        PoolList = new List<GameObject>();
        Instance = this;
    }

	void Start () {
      
        for (int i = 0; i < PoolingNumber; i++)
        {
            GameObject gameObject = GameObject.Instantiate(TargetObject);
            if (gameObject == null) Debug.Log("null");
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
                Debug.Log("find");
                return PoolList[i];
            }
        }
        return null;
    }
}
