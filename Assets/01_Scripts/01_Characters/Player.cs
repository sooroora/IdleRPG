using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character
{
    [SerializeField] private MonsterRayDetector monsterDetector;
    
    //인터페이스로 묶기
    [ SerializeField ] private MonsterRayDetector attackableDetector; 
    

    protected override void Init()
    {
        stateMachine = new PlayerStateMachine(this);

        monsterDetector.SetDetectDistance( 0.0f );
        monsterDetector.SetRayShape( EInteractionDetectorShape.Sphere );
        monsterDetector.SetDetectShapeRange( status.DetectRange );

        attackableDetector.SetDetectDistance( 0.0f );
        attackableDetector.SetRayShape( EInteractionDetectorShape.Cube );
        attackableDetector.SetDetectShapeRange( status.AttackRange );
        
    }


    public override void Respawn()
    {
        status.SetHealth(status.MaxHealth);
    }

    protected override void UpdateInternal()
    {
        if(GameManager.Instance.CurrentStage == null) return;
        if ( GameManager.Instance.CurrentStage.IsClear == true ) return;
        
        
        float waveDistance = Vector3.Distance( GameManager.Instance.CurrentStage.CurrentWavePoint.transform.position, this.transform.position ); 
        if ( stateMachine.CurrentState != stateMachine.Attack &&
             monsterDetector.CurrentTarget != null)
        {
            stateMachine.ChaseTarget(monsterDetector.CurrentTarget);
        }
        else if ( stateMachine.CurrentState == stateMachine.Idle &&
                  monsterDetector.CurrentTarget == null &&
                  waveDistance> 5.0f)
        {
            // 다음 웨이브 포인트로 이동
            WalkToWavePoint();
        }
        else if ( stateMachine.CurrentState == stateMachine.Idle &&
                  waveDistance <= 5.0f )
        {
            // 이번 웨이브 포인트의 남은 적 찾아 쫓아가기
            if(GameManager.Instance.CurrentStage.CurrentWavePoint.IsClear == false)
                stateMachine.ChaseTarget(GameManager.Instance.CurrentStage.CurrentWavePoint.Monsters[0]);
        }
        
        
    }

    public void WalkToWavePoint()
    {
        if(GameManager.Instance.CurrentStage != null)
            stateMachine.MoveToPosition(GameManager.Instance.CurrentStage.CurrentWavePoint.transform.position);
    }
    public override void Attack()
    {
        Monster[] targets = attackableDetector.CurrentTargets.ToArray();
        if ( targets.Length > 0 )
        {
            foreach ( Monster monster in targets )
            {
                monster.TakeDamage(status.Atk);
            }
            // foreach ( Monster target in attackableDetector.CurrentTargets )
            // {
            //     target.TakeDamage( status.Atk);
            // }
        }
    }
    
    

}
