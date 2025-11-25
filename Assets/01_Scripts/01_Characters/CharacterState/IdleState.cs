using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class IdleState : BaseState
{
    private float targetIdleTime = 0;
    public float nowIdleTime = 0f;

    public override void Enter()
    {
        targetIdleTime = Random.Range(0.0f, 5.0f);
        nowIdleTime = 0.0f;
    }

    public override void Update()
    {
        nowIdleTime += Time.deltaTime;
        if (nowIdleTime >= targetIdleTime)
        {
            stateMachine.ChangeState(stateMachine.WalkToTarget);
        }
        
    }


}
