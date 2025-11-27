using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterWavePoint : MonoBehaviour
{
    [ SerializeField ] private float range = 2.5f;
    [ SerializeField ] private int monsterCount = 5;

    [ Header( "Debug" ) ]
    [ SerializeField ] private bool showRange;

    public bool IsClear
    {
        get
        {
            if ( Monsters.Count <= 0 )
                return true;
            return false;
        }
    }

    public float Range => range;

    public List< Monster > Monsters => monsters;
    List< Monster > monsters;

    public void SpawnMonsters()
    {
        monsters = new List< Monster >();
        for ( int i = 0; i < monsterCount; i++ )
        {
            Vector3 spawnPosition = transform.position;
            spawnPosition = spawnPosition + new Vector3( Random.Range( -range, range ), 0, Random.Range( -range, range ) );
            Quaternion spawnRotation = Quaternion.Euler( 0, Random.Range( 0, 360 ), 0 );
            GameObject newMonster = PoolManager.Instance.Spawn( PoolType.Monster, spawnPosition, spawnRotation );
            Monster monster = newMonster.GetComponent< Monster >();


            monster.Respawn();
            monster.OnDieAction += ClearCheck;

            monsters.Add( monster );

        }
    }


    void ClearCheck()
    {
        for ( int i = monsters.Count - 1; i >= 0; i-- )
        {
            if ( monsters[ i ].Status.NowHealth <= 0 )
            {
                monsters[ i ].OnDieAction -= ClearCheck;
                monsters.Remove( monsters[ i ] );
            }
        }

        if ( IsClear )
        {
            GameManager.Instance.CurrentStage.NextWave();
            //Destroy( gameObject );
        }
    }

    void UpdateMonsters()
    {
    }

    private void OnDestroy()
    {
    }


    private void OnDrawGizmos()
    {
        //Gizmos.Li
        Gizmos.color = Color.red;
        if ( showRange )
        {
            //Gizmos.DrawWireSphere( transform.position, range );

            int segments = 32;
            float angleStep = 360f / segments;
            Vector3 prePoint = this.transform.position + new Vector3( Mathf.Cos( 0 ), 0, Mathf.Sin( 0 ) ) * range;

            List< Vector3 > lineList = new List< Vector3 >();
            lineList.Add( prePoint );
            for ( int i = 1; i <= segments; ++i )
            {
                float angle = angleStep * i * Mathf.Deg2Rad;

                Vector3 nextPoint = this.transform.position + new Vector3( Mathf.Cos( angle ), 0, Mathf.Sin( angle ) ) * range;

                lineList.Add( nextPoint );
            }

            Gizmos.DrawLineStrip( lineList.ToArray(), true );
        }
    }
}