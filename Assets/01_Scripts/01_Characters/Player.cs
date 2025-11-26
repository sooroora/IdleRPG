using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character
{
    private MonsterRayDetector monsterDetector;
    

    protected override void Init()
    {
        stateMachine = new PlayerStateMachine(this);
        monsterDetector = GetComponent<MonsterRayDetector>();
    }


    protected override void UpdateInternal()
    {
        // if (stateMachine.CurrentState != stateMachine.Attack)
        // {
        //     if (monsterDetector.CurrentTarget != null)
        //     {
        //         //SetTarget(monsterDetector.CurrentTarget.transform, 1.0f);
        //
        //         if (Vector3.Distance(this.transform.position, monsterDetector.CurrentTarget.transform.position) < 1.2f)
        //         {
        //             Debug.Log("Attack");
        //             stateMachine.ChangeState(stateMachine.Attack);
        //         }
        //     }
        // }

    }

    // public override void SetTarget(Transform _target, float _targetMaxDistance = 10.0f)
    // {
    //     base.SetTarget(_target, _targetMaxDistance);
    //     stateMachine.ChangeState(stateMachine.WalkToTarget);
    // }

    public void WalkToWavePoint()
    {
        stateMachine.MoveToPosition(GameManager.Instance.CurrentStage.CurrentWavePoint.transform.position);
    }
}
