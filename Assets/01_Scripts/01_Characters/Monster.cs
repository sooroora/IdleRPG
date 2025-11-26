using System;
using Unity.VisualScripting;

public class Monster : Character
{
    private PlayerRayDetector playerDetector;
    
    
    
    protected override void Init()
    {
        stateMachine = new MonsterStateMachine(this);
        playerDetector = GetComponent<PlayerRayDetector>();
        //SetTarget(GameManager.Instance.Player.transform);
    }


    protected override void UpdateInternal()
    {
        
        if (stateMachine.CurrentState == stateMachine.Idle &&
            playerDetector?.CurrentTarget != null)
        {
            stateMachine.ChaseTarget(playerDetector.CurrentTarget);
        }
        
    }

}
