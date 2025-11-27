using System.Collections.Generic;

public static class GameCommon
{
    public const int InventoryMaxSlot = 30;

    public static Dictionary< ConsumableType, string > ConsumableText = new()
    {
        { ConsumableType.Health, "체력" },
        { ConsumableType.Mana, "마나" },
        { ConsumableType.SpeedUp, "스피드업"},
    };
}