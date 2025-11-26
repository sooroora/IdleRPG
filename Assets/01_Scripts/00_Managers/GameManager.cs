using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SceneSingletonManager<GameManager>
{
    public PlayerInfo PlayerInfo => playerInfo;
    PlayerInfo playerInfo = new PlayerInfo();
    public Inventory Inventory => playerInfo.Inventory;
    
    public List<StageData> StageData => stageData;
    [SerializeField] private List<StageData> stageData;
    public Stage CurrentStage => currentStage;
    private Stage currentStage;

    public Player Player => player;
    [SerializeField]private Player player;
    [SerializeField] private Transform playerSpawnPoint;


    protected override void Init()
    {
        if(player == null)
            player = FindObjectOfType<Player>();
        
        
    }

    public void Start()
    {
        StartStage(0);
    }

    public void StartStage(int stageNum)
    {
        ScreenManager.Instance.StartFadeInOut(1.0f,
            () =>
            {
                if (currentStage != null)
                {
                    StopCurrentStage();
                }

                if (stageNum < stageData.Count && stageNum >= 0)
                {
                    Stage spawnedStage = Instantiate(stageData[stageNum].stage);
                    currentStage = spawnedStage;
                    currentStage.Init(stageData[stageNum]);
                    player.WalkToWavePoint();
                }
                
            }, 
            1.0f);
        
    }

    public void StopCurrentStage()
    {
        PoolManager.Instance.DeactivateAllPoolObjects(PoolType.Monster);
    }

    
}
