public abstract class BaseState
{
    protected CharacterStateMachine stateMachine;
    public void Init(CharacterStateMachine _stateMachine)
    {
        this.stateMachine = _stateMachine;
    }
    
    // 필요 없는 애는 안 쓸 수 있게 미리 선언해
    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
        
    }

    public virtual void Update()
    {
        
    }
    
    public virtual void FixedUpdate()
    {
        
    }

    public virtual void HandleInput()
    {
        
    }
}
