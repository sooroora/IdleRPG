public class WalkState : BaseState
{
    protected override void EnterInternal()
    {
        stateMachine.Character.Anim.SetBool("IsWalking", true);
        stateMachine.Character.Agent.isStopped = false;
        stateMachine.Character.Agent.updateRotation = true;
    }

    protected override void ExitInternal()
    {
        stateMachine.Character.Anim.SetBool("IsWalking", false);
    }
}
