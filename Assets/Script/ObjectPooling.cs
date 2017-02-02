using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ObjectPooling : BaseManager<ObjectPooling>
{
    public enum Type
    {
        Zombie, Bullet, Turret
    }

    [System.Serializable]
    public class VO
    {
        public Type type;
        public int poolingNumber;
        public string path;
    }

    Dictionary<Type, GameObject[]> ObjectPoller;
    Dictionary<Type, int> ObjectIndexer;
    VO[] Setting;

    public override void OnAwake()
    {

    }

    void Start()
    {
        ObjectPoller = new Dictionary<Type, GameObject[]>();
        ObjectIndexer = new Dictionary<Type, int>();
        //String json = JsonHelper.ToJson(Setting);
        //File.WriteAllText(Application.dataPath + "/Resources/Setting.json", json);
        Setting = JsonHelper.FromJson<VO>(ResourceManager.Instance.GetSetting());
        foreach (var set in Setting)
        {
            var tmp = ResourceManager.Instance.GetResource(set.path);

            ObjectPoller.Add(set.type, new GameObject[set.poolingNumber]);
            ObjectIndexer.Add(set.type, 0);
            for (int i = 0; i < set.poolingNumber; i++)
            {
                ObjectPoller[set.type][i] = GameObject.Instantiate(tmp);
                ObjectPoller[set.type][i].SetActive(false);
            }
        }
    }

    public GameObject GenerateObject(Type type, Vector3 position, Quaternion rotation, Transform parent = null)
    {
        GameObject gameObject = ObjectPoller[type][ObjectIndexer[type]++];

        gameObject.transform.position = position;
        gameObject.transform.rotation = rotation;
        gameObject.transform.parent = parent;
        gameObject.SetActive(true);
        if (ObjectIndexer[type] == ObjectPoller[type].Length)
        {
            ObjectIndexer[type] = 0;
        }

        return gameObject;
    }
}
