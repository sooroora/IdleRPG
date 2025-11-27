using UnityEngine;

public class AttackState : BaseState
{
    private Character target;

    private float nowDelay = 0;


    public void SetTarget( Character _target )
    {
        target = _target;
    }

    protected override void EnterInternal()
    {
        // if ( stateMachine.Character.gameObject.name == "1" )
        //     Debug.Log( "AAAA" );
        //     Debug.Log(stateMachine.Character.gameObject.name + " : " + dis  );
        stateMachine.Character.Agent.isStopped = true;
        stateMachine.Character.Agent.updateRotation = false;
    }

    protected override void ExitInternal()
    {
    }

    public override void Update()
    {
        float dis = Vector3.Distance( stateMachine.Character.gameObject.transform.position, target.transform.position );

        stateMachine.Character.LookAtTarget( target.transform );

        if ( nowDelay <= 0 )
        {
            if ( dis <= stateMachine.Character.Status.AttackRange )
            {
                stateMachine.Character.Anim.SetTrigger( "Attack" );
                nowDelay = stateMachine.Character.Status.AttackDealy;
            }
            else if ( dis > stateMachine.Character.Status.AttackRange + 0.1f )
            {
                stateMachine.Chase.SetTarget( target );
                stateMachine.ChangeState( stateMachine.Chase );
            }

            if ( target.Status.NowHealth <= 0 )
                stateMachine.ChangeState( stateMachine.Idle );
        }
        else
        {
            nowDelay -= Time.deltaTime;
        }
    }
}