using System;

public abstract class BaseState
{
    protected CharacterStateMachine stateMachine;

    public event Action OnEnterAction;
    public event Action OnExitAction;
    
    
    public void Init(CharacterStateMachine _stateMachine)
    {
        this.stateMachine = _stateMachine;
    }
    
    // 필요 없는 애는 안 쓸 수 있게 미리 선언해
    public void Enter()
    {
        OnEnterAction?.Invoke();
        EnterInternal();
    }

    protected abstract void EnterInternal();

    public virtual void Exit()
    {
        OnExitAction?.Invoke();
        ExitInternal();
    }
    
    protected abstract void ExitInternal();

    public virtual void Update()
    {
        
    }
    
    public virtual void FixedUpdate()
    {
        
    }

}
