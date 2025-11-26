using UnityEngine;
using UnityEngine.AI;

public class CharacterStateMachine : StateMachine
{
    public IdleState Idle;
    
    public ChaseState Chase;
    public MoveToState MoveTo;
    
    public AttackState Attack;
    public HitState Hit;
    
    
    public CharacterStateMachine(Character _character)
    {
        character = _character;
        
        Idle = CreateState<IdleState>();
        
        Chase = CreateState<ChaseState>();
        MoveTo = CreateState<MoveToState>();
        
        Attack = CreateState<AttackState>();
        Hit = CreateState<HitState>();
        
        
        ChangeState(Idle);
    }
    
    
    public T CreateState<T>() where T : BaseState, new()
    {
        T newState = new T();
        newState.Init(this);
        return newState;
    }


    public override void UpdateInternal()
    {
        
    }

    public override void ChaseTarget(Character _target, float _targetMaxDistance = 1f)
    {
        if(_target ==null) return;
        
        Chase.SetTarget(_target, _targetMaxDistance);
        ChangeState(Chase);
    }

    public override void MoveToPosition(Vector3 _position)
    {
        if (NavMesh.SamplePosition(_position, out NavMeshHit hit, 10f, NavMesh.AllAreas))
        { 
            MoveTo.SetTargetPosition(hit.position);
            ChangeState(MoveTo);
            return;
        }
    }
}
