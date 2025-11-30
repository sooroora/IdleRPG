using System.Collections.Generic;

public static class GameCommon
{
    public const int InventoryMaxSlot = 30;

    public static Dictionary< ConsumableType, string > ConsumableText = new()
    {
        { ConsumableType.HealthRestore, "체력 회복" },
        { ConsumableType.SpeedUp, "스피드 증가"},
        { ConsumableType.AttackUp, "공격력 증가"},
        
    };

    public const float ResellRate = 0.1f;
}