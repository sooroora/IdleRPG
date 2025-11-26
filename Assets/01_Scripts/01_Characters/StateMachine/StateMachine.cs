using UnityEngine;

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
        
        //Debug.Log(character.gameObject.name + " : " + currentState.GetType().Name);
        currentState?.Enter();
    }

    public virtual void Update()
    {
        currentState?.Update();
        UpdateInternal();
    }

    public void FixedUpdate()
    {
        currentState?.FixedUpdate();
    }

    public abstract void UpdateInternal();

    public abstract void ChaseTarget(Character _target, float _targetMaxDistance = 1f);

    public abstract void MoveToPosition(Vector3 _target);

}
    
