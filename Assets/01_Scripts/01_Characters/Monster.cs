public class Monster : Character
{
    protected override void Init()
    {
        
        stateMachine = new MonsterStateMachine(this);
    }
}
