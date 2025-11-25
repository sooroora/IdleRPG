public class PlayerStateMachine : CharacterStateMachine
{
    
    public PlayerStateMachine(Character _character) : base(_character)
    {
        
    }

    public override void Update()
    {
        
        if (CurrentState is IControllable c)
        {
            c.HandleInput();
        }
        
        base.Update();
    }

}