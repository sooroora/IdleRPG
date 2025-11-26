using UnityEngine;

public class AttackState:BaseState
{
    private Character target;

    private float nowDelay = 0;

    private float attackRange = 0.3f;

    public void SetTarget(Character _target)
    {
        target = _target;
        nowDelay = 0;
    }

    protected override void EnterInternal()
    {
        stateMachine.Character.Agent.isStopped = true;
        stateMachine.Character.Agent.updateRotation = false;
    }

    protected override void ExitInternal()
    {
        
    }

    public override void Update()
    {
        stateMachine.Character.LookAtTarget(target.transform);
        float dis = Vector3.Distance(stateMachine.Character.Agent.destination, target.transform.position);
        
        if (nowDelay <= 0)
        {
            if (dis <= attackRange)
            {
                stateMachine.Character.Anim.SetTrigger("Attack");
                nowDelay = 1.0f;
            }
        }
        else
        {
            nowDelay -= Time.deltaTime;
        }
        
        
        if (dis > 1.5f)
        {
            stateMachine.Chase.SetTarget(target);
            stateMachine.ChangeState(stateMachine.Chase);
        }
    }

}
