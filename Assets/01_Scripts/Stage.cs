using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public MonsterWavePoint CurrentWavePoint => currentWavePoint;
    MonsterWavePoint currentWavePoint;
    [ SerializeField ] List< MonsterWavePoint > monsterWavePoint;

    private int nowWave = -1;
    
    public void Init()
    {
        NextWave();
    }

    public void NextWave()
    {
        nowWave++;
        
        if ( nowWave >= monsterWavePoint.Count )
        {
            // clear
            return;
        }
        
        currentWavePoint = monsterWavePoint[nowWave];
    }
}