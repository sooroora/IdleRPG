public class CharacterStateMachine : StateMachine
{
    public IdleState Idle;
    public WalkToTargetState WalkToTarget;
    public AttackState Attack;
    public HitState Hit;
    
    public CharacterStateMachine(Character _character)
    {
        character = _character;
        
        Idle = CreateState<IdleState>();
        WalkToTarget = CreateState<WalkToTargetState>();
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
}
