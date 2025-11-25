using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneSingletonManager : MonoBehaviour
{
    protected static SceneSingletonManager instance;
 

    protected virtual void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        
        Init();
    }


    protected virtual void Init()
    {
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
