using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseManager<T> : MonoBehaviour where T : BaseManager<T>{
    public static T Instance;
    public abstract void OnAwake();
    void Awake()
    {
        Instance = (T)this;
        OnAwake();
    }
}
