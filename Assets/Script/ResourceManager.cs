using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : BaseManager<ResourceManager> {

    Dictionary<String, UnityEngine.Object> Resources;
    public List<String> Paths;
    String Setting;
    public override void OnAwake()
    {
        Resources = new Dictionary<string, UnityEngine.Object>();
        Setting = UnityEngine.Resources.Load("setting").ToString();
        foreach (var path in Paths)
        {
            Resources[path] = UnityEngine.Resources.Load(path);
        }
    }

    public UnityEngine.Object GetResource(String path)
    {
        return Resources[path];
    }

    public String GetSetting()
    {
        return Setting;
    }

    public void UnloadResource(String path)
    {
        UnityEngine.Resources.UnloadAsset(GetResource(path));
    }
}
