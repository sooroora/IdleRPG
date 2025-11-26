using System;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    StageData stageData;
    public MonsterWavePoint CurrentWavePoint => currentWavePoint;
    MonsterWavePoint currentWavePoint;
    [ SerializeField ] List< MonsterWavePoint > monsterWavePoint;

    public int NowWave => nowWave;
    private int nowWave = -1;
    
    public void Init(StageData _stageData)
    {
        stageData = _stageData;
        NextWave();
    }

    private void Update()
    {
        

    }

    public bool NextWave()
    {
        nowWave++;
        
        if ( nowWave >= monsterWavePoint.Count )
        {
            // clear
            return true;
        }
        
        currentWavePoint = monsterWavePoint[nowWave];
        currentWavePoint.SpawnMonsters();
        return false;
    }
}