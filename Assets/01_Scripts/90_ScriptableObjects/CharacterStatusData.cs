using UnityEngine;


[ CreateAssetMenu( fileName = "New PlayerStatusData", menuName = "Player/PlayerStatusData" ) ]
public class CharacterStatusData : ScriptableObject
{
    [ Header( "Status" ) ]
    public int maxHealth = 100;
    public float healthNaturalRecoveryRate = 1.0f;
    public int healthNaturalRecovery = 0;

    [Space(5)]
    public int maxMana = 50;
    public float manaNaturalRecoveryRate = .5f;
    public int manaNaturalRecovery = 1;
    
    [Space(10)]
    public int defaultAtk = 2;
    
    [ Header( "Behaviour" ) ]
    public float moveSpeed = 5.0f;
    
    [Space(5)]
    public float AttackDelay = 0.5f;
    public float AttackRange = 1.0f;


}