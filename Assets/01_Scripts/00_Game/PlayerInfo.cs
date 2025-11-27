using System;
using UnityEngine;

// 저장할 땐 이거 저장하면 돼
public class PlayerInfo
{
    public int Level => level;
    private int level;

    public int RequireExp => requiredExp;
    public int NowExp => nowExp;

    private int requiredExp;
    private int nowExp;
    public Inventory Inventory => inventory;
    Inventory inventory = new Inventory();

    public int Gold => gold;
    private int gold;

    public int CurrentStage;
    private int currentStage;

    public event Action OnAddExpAction;
    public event Action OnLevelUpAction;
    
    public event Action OnAddGoldAction;
    public PlayerInfo()
    {
        level = 1;
        nowExp = 0;
        requiredExp = GetRequiredExp( level );

        inventory = new Inventory();
    }

    public void AddExp( int exp )
    {
        nowExp += exp;

        OnAddExpAction?.Invoke();
        
        if ( nowExp >= requiredExp )
        {
            LevelUp();
        }
    }

    public void AddGold( int _gold )
    {
        gold += _gold;
        OnAddGoldAction?.Invoke();
    }

    void LevelUp()
    {
        while (nowExp >= requiredExp)
        {
            level++;
            nowExp -= requiredExp;
            requiredExp = GetRequiredExp(level);
        }
        
        OnLevelUpAction?.Invoke();
    }
    
    
    // 지피티의 경험치 식 킈키키
    public static int GetRequiredExp( int level )
    {
        float baseExp = 100f;
        float growth = 1.15f;
        float curve = 2f;

        float required = baseExp * Mathf.Pow( level, curve ) * Mathf.Pow( growth, level - 1 );

        return Mathf.RoundToInt( required );
    }
}