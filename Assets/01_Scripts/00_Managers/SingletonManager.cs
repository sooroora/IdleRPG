using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonManager : MonoBehaviour
{
    public static SingletonManager Instance => instance;
    private static SingletonManager instance;
   

    protected virtual void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
        
        Init();
    }


    protected virtual void Init()
    {
    }

}
