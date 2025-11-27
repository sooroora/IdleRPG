using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class ChaseState : WalkState
{
    Character target;
    private float targetMaxDistance;

    private float nowSearchTargetDelay;


    public void SetTarget( Character _target, float _targetMaxDistance = 1f )
    {
        target = _target;
        targetMaxDistance = _targetMaxDistance;
    }

    protected override void EnterInternal()
    {
        base.EnterInternal();
        SetDestination();
    }

    public override void Update()
    {
        float dis = Vector3.Distance( stateMachine.Character.gameObject.transform.position, target.transform.position );

        // if(stateMachine.Character.gameObject.name=="1")
        //     Debug.Log(dis);

        if ( dis <= stateMachine.Character.Status.AttackRange )
        {
            stateMachine.Attack.SetTarget( target );
            stateMachine.ChangeState( stateMachine.Attack );
            return;
        }


        if ( nowSearchTargetDelay < 0 )
        {
            if ( dis >= stateMachine.Character.Status.RedetectRange )
            {
                SetDestination();
            }

            return;
        }

        nowSearchTargetDelay -= Time.deltaTime;
    }

    void SetDestination()
    {
        
        
        
        Vector3 dirToTarget = (target.transform.position - stateMachine.Character.transform.position).normalized;

        float angleOffset = Random.Range(-5f, 5f);
        Quaternion rot = Quaternion.Euler(0f, angleOffset, 0f);
        Vector3 offsetDir = rot * dirToTarget;

        float dist = Random.Range(
            stateMachine.Character.Status.AttackRange * 0.7f,
            stateMachine.Character.Status.AttackRange
        );

        Vector3 randomPos = target.transform.position - offsetDir * dist;
        
        // Vector3 randomPos = target.transform.position + Utility.GetRandomDirection()
        //   * Random.Range( stateMachine.Character.Status.AttackRange * 0.7f, stateMachine.Character.Status.AttackRange );

        if ( NavMesh.SamplePosition( randomPos, out NavMeshHit hit, targetMaxDistance, NavMesh.AllAreas ) )
        {
            stateMachine.Character.Agent.SetDestination( hit.position );
        }
        else
        {
            stateMachine.ChangeState( stateMachine.Idle );
        }

        nowSearchTargetDelay = stateMachine.Character.Status.RedetectTime;
    }
}