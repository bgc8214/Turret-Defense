using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : BaseManager<ResourceManager> {

    Dictionary<String, GameObject> Resources;
    public List<String> Paths;
    String Setting;
    public override void OnAwake()
    {
        Resources = new Dictionary<string, GameObject>();
        Setting = UnityEngine.Resources.Load("setting").ToString();
        foreach (var path in Paths)
        {
            Resources[path] = UnityEngine.Resources.Load<GameObject>(path);
        }
    }

    public GameObject GetResource(String path)
    {
        return Resources[path];
    }

    public String GetSetting()
    {
        return Setting;
    }

	void Update () {
		
	}
}
