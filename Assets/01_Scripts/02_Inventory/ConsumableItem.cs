using System;

public class ConsumableItem : Item
{
    public ConsumableEffect[] Consumable => consumable;
    private ConsumableEffect[] consumable;

    public ConsumableItem( ItemData itemData ) : base( itemData )
    {
        ConsumableItemData consumableItemData = ( ConsumableItemData )itemData;
        if ( consumableItemData == null ) return;

        consumable = consumableItemData.Consumables;
    }

    protected override void UseInternal( Player player )
    {
        for ( int i = 0; i < consumable.Length; i++ )
        {
            switch ( consumable[ i ].consumableType )
            {
                case ConsumableType.HealthRestore :
                    player.Status.AddHealth(consumable[ i ].amount);
                    break;
                case ConsumableType.SpeedUp :
                    
                    break;
                case ConsumableType.AttackUp :
                    break;
            }
        }
    }
}