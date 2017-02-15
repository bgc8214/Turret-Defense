using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : BaseManager<ResourceManager> {

    Dictionary<String, UnityEngine.Object> Resources;
    String JSONSetting;
    ObjectPooling.VO[] Setting;
    public override void OnAwake()
    {
        Resources = new Dictionary<string, UnityEngine.Object>();
        JSONSetting = UnityEngine.Resources.Load("setting").ToString();
        Setting = JsonHelper.FromJson<ObjectPooling.VO>(JSONSetting);
        foreach (var set in Setting)
        {
            Resources[set.path] = UnityEngine.Resources.Load(set.path);
        }
    }

    public UnityEngine.Object GetResource(String path)
    {
        return Resources[path];
    }

    public String GetSetting()
    {
        return JSONSetting;
    }

    public void UnloadResource(String path)
    {
        UnityEngine.Resources.UnloadAsset(GetResource(path));
    }
}
