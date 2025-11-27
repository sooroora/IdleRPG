using System.Collections.Generic;
using UnityEngine;

[ CreateAssetMenu( fileName = "MonsterRewardData", menuName = "Monster/MonsterRewardData" ) ]
public class MonsterRewardData : ScriptableObject
{
    public int exp;
    public int gold;
    public List< ItemData > gettableItems;
}