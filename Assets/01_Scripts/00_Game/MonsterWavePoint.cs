using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterWavePoint : MonoBehaviour
{
    [ SerializeField ] private float range = 2.5f;
    [ SerializeField ] private int monsterCount = 5;

    [ Header( "Debug" ) ]
    [ SerializeField ] private bool showRange;

    public float Range => range;

    public void SpawnMonsters()
    {
        for (int i = 0; i < monsterCount; i++)
        {
            Vector3 spawnPosition = transform.position;
            spawnPosition = spawnPosition + new Vector3(Random.Range(-range, range), 0, Random.Range(-range, range));
            Quaternion spawnRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            PoolManager.Instance.Spawn(PoolType.Monster, spawnPosition, spawnRotation);
            //o.name = i.ToString();
        }
    }

    private void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if ( showRange )
            Gizmos.DrawWireSphere( transform.position, range );
    }

   
}