using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private MonsterRayDetector monsterDetector;
    
    //public override Transform Target => monsterDetector.CurrentTarget.transform;
    
    protected override void Init()
    {
        stateMachine = new PlayerStateMachine(this);
    }


    protected void Update()
    {
        base.Update();

    }
    
    
}
