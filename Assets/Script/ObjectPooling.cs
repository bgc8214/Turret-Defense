using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooling : BaseManager<ObjectPooling>
{
    public enum ObjectType
    {
        Zombie, Turret, Bullet
    }

    [System.Serializable] // 사용자가 만든 클래스는 직렬화를 해주어야 보인다.
    public class ObjectSetting
    {
        public ObjectType Type; // enum
        public string path;
        public int PoolingNumber;
    }
    Dictionary<ObjectType, GameObject[]> ObjectPooler;
    Dictionary<ObjectType, int> ObjectIndex;
    public ObjectSetting[] Setting;
    public override void OnAwake()
    {
        Debug.Log("Called");
        ObjectPooler = new Dictionary<ObjectType, GameObject[]>();
        ObjectIndex = new Dictionary<ObjectType, int>();
        foreach (var set in Setting)
        {
            ObjectPooler.Add(set.Type, new GameObject[set.PoolingNumber]);
            ObjectIndex.Add(set.Type, 0);
            // 원본의 리소스를 가져온다;
            var temp = Resources.Load<GameObject>(set.path);
            for (int i = 0; i < set.PoolingNumber; i++)
            {
                ObjectPooler[set.Type][i] = GameObject.Instantiate(temp);
                ObjectPooler[set.Type][i].SetActive(false);
            }
        }
    }
    void Start()
    {
        //GenerateObject(ObjectType.Zombie, Vector3.zero, Quaternion.identity);
    }
    public GameObject GenerateObject(ObjectType type, Vector3 position, Quaternion rotation, Transform parent = null)
    {
        Debug.Log("genenen");
        ObjectIndex[type]++;
        if (ObjectIndex[type] == ObjectPooler[type].Length)
            ObjectIndex[type] = 0;
        GameObject obj = ObjectPooler[type][ObjectIndex[type]];
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.transform.parent = parent;
        obj.SetActive(true);
        return ObjectPooler[type][ObjectIndex[type]];
    }
}
