using System;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    StageData stageData;
    public StageData StageData => stageData;
    public MonsterWavePoint CurrentWavePoint => currentWavePoint;
    public string StageName => stageData.name;
    MonsterWavePoint currentWavePoint;
    [ SerializeField ] List< MonsterWavePoint > monsterWavePoint;

    public event Action OnClearAction;
    public int NowWave => nowWave;
    private int nowWave = -1;

    public bool IsClear
    {
        get
        {
            if ( monsterWavePoint.Count <= nowWave ) return true;
            return false;
        }
    }

    public void Init( StageData _stageData )
    {
        stageData = _stageData;
        NextWave();
    }

    private void Update()
    {
    }

    public void NextWave()
    {
        nowWave++;

        if ( nowWave >= monsterWavePoint.Count )
        {
            // clear
            ClearStage();
            return;
        }

        currentWavePoint = monsterWavePoint[ nowWave ];
        currentWavePoint.SpawnMonsters();
    }

    void ClearStage()
    {
        OnClearAction?.Invoke();
    }
}