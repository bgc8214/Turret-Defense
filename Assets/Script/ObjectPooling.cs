using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{

    public static ObjectPooling Instance;
    public List<GameObject> TargetObjects;
    public List<int> PoolingNumbers;
    public List<GameObject> PoolList;
    void Awake()
    {
        PoolList = new List<GameObject>();
        Instance = this;
    }

    void Start()
    {
        for (int j = 0; j < TargetObjects.Count; j++)
        {
            for (int i = 0; i < PoolingNumbers[j]; i++)
            {
                GameObject gameObject = GameObject.Instantiate(TargetObjects[j]);
                if (gameObject == null) Debug.Log("null");
                gameObject.SetActive(false);
                PoolList.Add(gameObject);
            }
        }
    }
    public GameObject popObject(int number)
    {
        int start = 0;
        for (int k = 0; k < number; k++)
        {
            start += PoolingNumbers[k];
        }
        for (int i = start; i < start+PoolingNumbers[number]; i++)
        {
            if (!PoolList[i].activeInHierarchy)
            {
                return PoolList[i];
            }
        }
        return null;
    }
}
