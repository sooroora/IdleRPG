using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SceneSingletonManager
{
    public static GameManager Instance => instance as GameManager;
    public Stage CurrentStage => currentStage;
    private Stage currentStage;

    public Player Player => player;
    private Player player;


    protected override void Init()
    {
        player = FindObjectOfType<Player>();
    }


    public void StartState()
    {
        
    }
    // [SerializeField]
    // IEnumerator FadeInOutAction( Action action, float fadeTime = 1.0f )
    // {
    //     
    // }
}
