using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ CreateAssetMenu( fileName = "StageData", menuName = "Stage/StageData" ) ]
public class StageData : ScriptableObject
{
    public Stage stage;

    [Header("보상")]
    public int clearExp;
    public int clearGold;
    public List<ItemData> reward;
}
