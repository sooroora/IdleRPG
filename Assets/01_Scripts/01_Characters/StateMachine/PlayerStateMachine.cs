using UnityEngine;

public class PlayerStateMachine : CharacterStateMachine
{
    private Player player;
    
    public PlayerStateMachine(Character _character) : base(_character)
    {
        player = _character as Player;    
    }

    public override void UpdateInternal()
    {
        
    }

}