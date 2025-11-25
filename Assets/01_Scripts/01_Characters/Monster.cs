public class Monster : Character
{
    protected override void Init()
    {
        stateMachine = new MonsterStateMachine(this);
        SetTarget(GameManager.Instance.Player.transform);
    }
    
    
}
