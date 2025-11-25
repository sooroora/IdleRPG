using System;
using UnityEngine;

public class MonsterWavePoint : MonoBehaviour
{
    [ SerializeField ] private float range = 2.5f;
    [ SerializeField ] private int monsterCount = 5;

    [ Header( "Debug" ) ]
    [ SerializeField ] private bool showRange;

    public float Range => range;

    public void SpawnMonsters()
    {
        
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if ( showRange )
            Gizmos.DrawSphere( transform.position, range );
    }
}