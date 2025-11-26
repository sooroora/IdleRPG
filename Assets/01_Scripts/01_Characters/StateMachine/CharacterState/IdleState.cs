using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class IdleState : BaseState
{
    private float targetIdleTime = 0;
    public float nowIdleTime = 0f;

    protected override void EnterInternal()
    {
        stateMachine.Character.Agent.updateRotation = false;
        // targetIdleTime = Random.Range(0.0f, 5.0f);
        // nowIdleTime = 0.0f;
    }

    protected override void ExitInternal()
    {
        
    }

    public override void Update()
    {
        // nowIdleTime += Time.deltaTime;
        // if (nowIdleTime >= targetIdleTime)
        // {
        //     stateMachine.ChangeState(stateMachine.WalkToTarget);
        // }
    }
    
}
