using Unity.VisualScripting;
using UnityEngine;

public class MoveToState :WalkState
{
    private Vector3 target;

    public void SetTargetPosition(Vector3 _target)
    {
        target = _target;
    }

    protected override void EnterInternal()
    {
        base.EnterInternal();
        stateMachine.Character.Agent.SetDestination(target);
    }

    public override void Update()
    {
        if (stateMachine.Character.Agent.remainingDistance <= stateMachine.Character.Agent.stoppingDistance)
        {
            stateMachine.ChangeState(stateMachine.Idle);
        }
    }

}
