using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class ChaseState : WalkState
{

    Character target;
    private float targetMaxDistance;

    private float searchTargetDelay = 2.0f;
    private float nowSearchTargetDelay;

    private float attackRange = 0.3f;

    public void SetTarget(Character _target, float _targetMaxDistance = 1f)
    {
        target = _target;
        targetMaxDistance = _targetMaxDistance;
        nowSearchTargetDelay = searchTargetDelay;
    }
    
    protected override void EnterInternal()
    {
        base.EnterInternal();
        SetDestination();
    }

    public override void Update()
    {

        float dis = Vector3.Distance(stateMachine.Character.Agent.destination, target.transform.position);
        
        // if(stateMachine.Character.gameObject.name=="1")
        //     Debug.Log(dis);
        
        if (dis <= attackRange)
        {
            stateMachine.Attack.SetTarget(target);
            stateMachine.ChangeState(stateMachine.Attack);
            return;
        }


        if (nowSearchTargetDelay < 0)
        {
            if (dis > 2.0f)
            {
                SetDestination();
            }

            nowSearchTargetDelay = searchTargetDelay;
            return;
        }
        
        nowSearchTargetDelay -= Time.deltaTime;

    }

    void SetDestination()
    {
        Vector3 randomPos = target.transform.position + Utility.GetRandomDirection() * Random.Range(0.2f,
            attackRange);
        
        if (NavMesh.SamplePosition(randomPos, out NavMeshHit hit, targetMaxDistance, NavMesh.AllAreas))
        {
            stateMachine.Character.Agent.SetDestination(hit.position);
        }
        else
        {
            stateMachine.ChangeState(stateMachine.Idle);
        }
       
    }


}
