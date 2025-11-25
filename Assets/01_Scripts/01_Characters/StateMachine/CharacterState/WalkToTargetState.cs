using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class WalkToTargetState : BaseState, IControllable
{

    public override void Enter()
    {
        SetDestination();
    }

    public override void Update()
    {
        if (stateMachine.Character.Agent.remainingDistance <= stateMachine.Character.Agent.stoppingDistance)
        {
            stateMachine.ChangeState(stateMachine.Idle);

            float rate = Random.Range(0.0f, 1.0f);
            if (rate < 0.3f)
            {
                stateMachine.ChangeState(stateMachine.Idle);
            }
            else
            {
                SetDestination();
            }
        }

    }

    void SetDestination()
    {
        if (stateMachine.Character.Target == null)
        {
            Vector3 randomPos = stateMachine.Character.transform.position + 
                                Utility.GetRandomForwardDirection(stateMachine.Character.transform.forward) * Random.Range(5f, 10f);
            
            if (NavMesh.SamplePosition(randomPos, out NavMeshHit hit, 10f, NavMesh.AllAreas))
            {
                stateMachine.Character.Agent.SetDestination(hit.position);
                return;
            }
            else
            {
                randomPos = stateMachine.Character.transform.position + Utility.GetRandomForwardDirection(-stateMachine.Character.transform.forward)* Random.Range(5f, 10f);
                if (NavMesh.SamplePosition(randomPos, out hit, 10f, NavMesh.AllAreas))
                {
                    stateMachine.Character.Agent.SetDestination(hit.position);
                    return;
                }
            }
        }
        else
        {
            Vector3 randomPos = stateMachine.Character.Target.position + Utility.GetRandomDirection() * Random.Range(1f, 10f);
            if (NavMesh.SamplePosition(randomPos, out NavMeshHit hit, 10f, NavMesh.AllAreas))
            {
                stateMachine.Character.Agent.SetDestination(hit.position);
                return;
            }
        }

        stateMachine.ChangeState(stateMachine.Idle);
    }


    public void HandleInput()
    {
    }
}
