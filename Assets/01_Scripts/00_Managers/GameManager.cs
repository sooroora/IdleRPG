using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance => instance;
    private static GameManager instance;

    public int CurrentStage => currentStage;
    private int currentStage;

    public Player Player => player;
    private Player player;

    protected void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        
        Init();
    }

    public void Init()
    {
        player = FindObjectOfType<Player>();
    }
    
    private void OnDestroy()
    {
        instance = null;
    }
}
