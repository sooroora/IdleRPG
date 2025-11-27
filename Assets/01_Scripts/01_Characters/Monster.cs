using System;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : Character
{
    [SerializeField] private PlayerRayDetector playerDetector;
    [SerializeField] private PlayerRayDetector attackableDetector;
    [SerializeField] private MonsterRewardData rewardData;
    
    
    
    protected override void Init()
    {
        playerDetector.SetDetectDistance( 0.0f );
        playerDetector.SetRayShape( EInteractionDetectorShape.Sphere );
        playerDetector.SetDetectShapeRange( status.DetectRange );
        
        attackableDetector.SetDetectDistance( 0.0f );
        attackableDetector.SetRayShape( EInteractionDetectorShape.Cube );
        attackableDetector.SetDetectShapeRange( status.AttackRange );
        
        OnDieAction += () =>
        {
            stateMachine.ChangeState( stateMachine.Die );
            
            GameManager.Instance.AddGold(rewardData.gold);
            GameManager.Instance.AddExp(rewardData.exp);
            
            StartDelayAction( () =>
            {
                this.gameObject.SetActive( false );
            }, 1.0f );
        };
    }

    public override void Respawn()
    {
        status.Init(); 
        
        stateMachine = new MonsterStateMachine(this);
        stateMachine.ChangeState(stateMachine.Idle);
        Anim.Play( "Idle", 0, 0 );
        
        playerDetector.SetDetectDistance( 0.0f );
        playerDetector.SetRayShape( EInteractionDetectorShape.Sphere );
        playerDetector.SetDetectShapeRange( status.DetectRange );
        
        attackableDetector.SetDetectDistance( 0.0f );
        attackableDetector.SetRayShape( EInteractionDetectorShape.Cube );
        attackableDetector.SetDetectShapeRange( status.AttackRange );
        
        
    }

    protected override void UpdateInternal()
    {
        
        if (stateMachine.CurrentState == stateMachine.Idle &&
            playerDetector?.CurrentTarget != null)
        {
            stateMachine.ChaseTarget(playerDetector.CurrentTarget);
        }
        
    }

    public override void Attack()
    {
        if ( attackableDetector?.CurrentTarget != null )
        {
            attackableDetector.CurrentTarget.TakeDamage(
                status.Atk);
        }
    }
}
