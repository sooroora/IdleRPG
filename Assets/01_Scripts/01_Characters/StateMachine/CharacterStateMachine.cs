public class CharacterStateMachine : StateMachine
{
    public IdleState Idle;
    public WalkToTargetState WalkToTarget;
    public FollowState Follow;
    public AttackState Attack;
    
    public CharacterStateMachine(Character _character)
    {
        character = _character;
        
        Idle = CreateState<IdleState>();
        WalkToTarget = CreateState<WalkToTargetState>();
        Follow = CreateState<FollowState>();
        Attack = CreateState<AttackState>();
        
        ChangeState(Idle);
    }


    
    public T CreateState<T>() where T : BaseState, new()
    {
        T newState = new T();
        newState.Init(this);
        return newState;
    }
}
