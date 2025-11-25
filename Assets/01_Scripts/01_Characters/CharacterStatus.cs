using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    [ SerializeField ] private CharacterStatusData statusData;

    public float MoveSpeed => statusData.moveSpeed;
    public float AttackDealy => statusData.AttackDelay;

    public float NowHealth => health.CurrentValue;
    public float NowMana => mana.CurrentValue;

    public float Atk => statusData.defaultAtk;
    public float AttackRange => statusData.AttackRange;
    
    public Condition HealthCondition => health;
    public Condition ManaCondition => mana;
    
    private Condition health;
    private Condition mana;
    
    

    private void Awake()
    {
        health = new Condition( statusData.maxHealth, statusData.healthNaturalRecovery, statusData.healthNaturalRecoveryRate );
        mana = new Condition(statusData.maxMana, statusData.manaNaturalRecovery, statusData.manaNaturalRecoveryRate);
       
        StartNaturalChangeRoutin( health );
        StartNaturalChangeRoutin( mana );
    }

    public void AddHealth( int damage )
    {
        health.AddCurrentValue( damage );
    }

    public void AddMana( float amount )
    {
        mana.AddCurrentValue( amount );
    }

    public void StartNaturalChangeRoutin( Condition condition )
    {
        if ( condition.ChangeRoutine != null )
        {
            StopCoroutine( condition.ChangeRoutine );
        }

        Coroutine newCoroutine = StartCoroutine( NaturalChangeRoutine( condition ) );
        condition.SetChangeRoutine( newCoroutine );
    }

    IEnumerator NaturalChangeRoutine( Condition targetCondition )
    {
        while ( true )
        {
            yield return new WaitForSeconds( targetCondition.NaturalChangeRate );
            targetCondition.AddNaturalChangeValue( targetCondition.NaturalChangeValue );
            
            while ( true )
            {
                if ( targetCondition.IsUsing == true )
                {
                    targetCondition.SetUsingCondition( false );
                    yield return new WaitForSeconds( 3.0f );
                }

                if ( targetCondition.IsUsing == false )
                    break;
            }
        }
    }
    
    public void StartOtherChangeRoutine(Condition condition, float amount, float rate)
    {
        if ( condition.ChangeRoutine != null )
        {
            StopCoroutine( condition.ChangeRoutine );
        }

        Coroutine newCoroutine = StartCoroutine( OtherChangeRoutine( condition, amount, rate) );
        condition.SetChangeRoutine( newCoroutine );
    }

    public void StopOtherChangeRoutine(Condition condition)
    {
        if ( condition.ChangeRoutine != null )
        {
            StopCoroutine( condition.ChangeRoutine );
        }
        
        StartNaturalChangeRoutin( condition );
    }
    
    IEnumerator OtherChangeRoutine( Condition targetCondition, float amount, float rate )
    {
        while ( true )
        {
            targetCondition.AddNaturalChangeValue(amount);
            yield return new WaitForSeconds(rate);
        }
    }
}