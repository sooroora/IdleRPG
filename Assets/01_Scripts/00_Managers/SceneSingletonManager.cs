using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneSingletonManager<T> : MonoBehaviour where T : SceneSingletonManager<T>
{
    public static T Instance => instance;
    protected static T instance;
 

    protected virtual void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = (T)this;
        
        Init();
    }


    protected virtual void Init()
    {
    }

    private void OnDestroy()
    {
        //안전하게 null 로 비우기
        instance = null;
    }
}
