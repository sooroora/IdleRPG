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

    
    // ui 묶어야
    [SerializeField] HudUI hudUI;
    [SerializeField] ResultUI resultUI;
    
    protected override void Init()
    {
        Time.timeScale = 2.0f;
        
        if(player == null)
            player = FindObjectOfType<Player>();
        
        playerInfo = new PlayerInfo();
        
        hudUI.SetExpBar( playerInfo.NowExp, playerInfo.RequireExp );
        hudUI.SetGoldText(playerInfo.Gold);
        hudUI.SetStageText( "" );
        hudUI.SetLevelText(playerInfo.Level);

        resultUI.ReplayButton.onClick.AddListener(ReplayStage);
        resultUI.NextStageButton.onClick.AddListener(StartNextStage);
        
        playerInfo.OnLevelUpAction += ()=>
        {
            hudUI.SetLevelText( playerInfo.Level );
        };

        playerInfo.OnAddExpAction += () =>
        {
            hudUI.StartSetExpBarRoutine( playerInfo.NowExp, playerInfo.RequireExp );
        };

        playerInfo.OnAddGoldAction += () =>
        {
            hudUI.StartSetGoldTextRoutine( playerInfo.Gold );
        };

    }

    public void Start()
    {
        StartCoroutine(DelayAction(  () =>
        {
            StartStage( playerInfo.CurrentStage );
        }, 1.0f ));
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
                    
                    currentStage.OnClearAction += ClearStage;
                    
                    hudUI.SetStageText( currentStage.StageName );
                    
                    player.transform.position = playerSpawnPoint.position;
                    player.Respawn();
                    player.WalkToWavePoint();
                }
                
            }, 
            1.0f);
        
    }

    public void StopCurrentStage()
    {
        PoolManager.Instance.DeactivateAllPoolObjects(PoolType.Monster);
        Destroy(currentStage.gameObject);
    }


    IEnumerator DelayAction( Action action, float delay )
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
    
    public void AddGold(int gold)
    {
        playerInfo.AddGold( gold );
    }

    public void AddExp( int exp )
    {
        playerInfo.AddExp( exp );
    }

    void StartNextStage()
    {
        if (stageData.Count <= playerInfo.CurrentStage +1)
        {
            // 다음 스테이지가 없음
            StartStage( playerInfo.CurrentStage );
            return;
        }
        
        playerInfo.SetCurrentStage(playerInfo.CurrentStage + 1);
        StartStage( playerInfo.CurrentStage );
    }

    void ReplayStage()
    {
        StartStage( playerInfo.CurrentStage );
    }

    public void SelectStage(int stageNum)
    {
        if(stageData.Count <= stageNum || stageNum < 0)
            return;
        
        playerInfo.SetCurrentStage(stageNum);
        StartStage( stageNum );
    }

    void ClearStage()
    {
        StartCoroutine(DelayAction(StartNextStage, 1.0f));
        //StartNextStage();
        // 얼레 방치형이라 result 있는것보다 없어야한다.
        //resultUI.OpenClearPopup( currentStage.StageData );
    }

    public void FailStage()
    {
        // 죽었을 때 처리 필요
        
        StartCoroutine(DelayAction(ReplayStage, 1.0f));
    }

}
