using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    protected override void Init()
    {
        stateMachine = new PlayerStateMachine(this);
    }
    
    
    
    
    
}
