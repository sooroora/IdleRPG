using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    [ SerializeField ] private CharacterStatusData statusData;
    
    [SerializeField] ConditionUI hpConditionUI;

    public float MoveSpeed => statusData.moveSpeed;
    public float AttackDealy => statusData.AttackDelay;

    public int MaxHealth => statusData.maxHealth;
    public float NowHealth => health.CurrentValue;
    public float NowMana => mana.CurrentValue;

    public int Atk => statusData.defaultAtk;
    public float AttackRange => statusData.AttackRange;
    public float DetectRange => statusData.DetectRange;
    
    public float RedetectRange => statusData.RedetectRange;
    public float RedetectTime => statusData.RedetectTime;
    
    public Condition HealthCondition => health;
    public Condition ManaCondition => mana;
    
    private Condition health;
    private Condition mana;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        health = new Condition( statusData.maxHealth, statusData.healthNaturalRecovery, statusData.healthNaturalRecoveryRate );
        mana = new Condition(statusData.maxMana, statusData.manaNaturalRecovery, statusData.manaNaturalRecoveryRate);
       
        StartNaturalChangeRoutin( health );
        StartNaturalChangeRoutin( mana );

        hpConditionUI?.Init(health);
    }

    public void AddHealth( int damage )
    {
        health.AddCurrentValue( damage );
    }

    public void SetHealth( int amount )
    {
        health.SetCurrentValue( amount );
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