public abstract class StateMachine
{
    public BaseState CurrentState => currentState;
    private BaseState currentState;
    
    public Character Character=>character;
    protected Character character;
    
    
    public StateMachine(){}
    public void ChangeState(BaseState state)
    {
        currentState?.Exit();
        currentState = state;
        currentState?.Enter();
    }

    public virtual void Update()
    {
        currentState?.Update();
    }

    public void FixedUpdate()
    {
        currentState?.FixedUpdate();
    }
    
}
    
