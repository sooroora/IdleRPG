using UnityEngine;

public class DieState : BaseState
{
    protected override void EnterInternal()
    {
        stateMachine.Character.Anim.SetTrigger("IsDead");
    }

    protected override void ExitInternal()
    {
    }
}