using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List< Item > Items => items;
    private List< Item > items;

    public event Action OnAddItemAction ;

    public Inventory()
    {
        items = new List< Item >();
    }

    public bool AddItem( Item item)
    {
        
        List< Item > findItems
            = items.FindAll( ( i ) =>
            {
                if ( item.Name == i.Name ) return true;
                return false;
            } );

        item.OnUse += OnItemUse;
        
        int remainCount = item.Count;

        if ( findItems.Count > 0 )
        {
            if ( item.CanStack )
            {
                for ( int i = 0; i < findItems.Count; i++ )
                {
                    if ( findItems[ i ].Count < findItems[ i ].MaxCount )
                    {
                        int originCount = findItems[ i ].Count;
                        int nowStackCount = findItems[ i ].AddCount( remainCount );
                        remainCount = remainCount - ( nowStackCount - originCount );

                        if ( remainCount == 0 )
                        {
                            break;
                        }
                    }
                }

                if ( remainCount == 0 )
                {
                    OnAddItemAction?.Invoke();
                    return true;
                }
            }
        }

        if ( items.Count >= GameCommon.InventoryMaxSlot ) return false;

        items.Add( item );
        
        OnAddItemAction?.Invoke();
        return true;
        
    }

    void RemoveItem( Item item )
    {
        if ( items.Contains( item ) )
        {
            item.OnUse -= OnItemUse;

            items.Remove( item );
        }
    }

    public void SellItem( Item item )
    {
        if ( items.Contains( item ) )
        {
            if ( item.CanStack )
            {
                if ( item.AddCount( -1 ) <= 0 )
                    RemoveItem( item );
            }
            else
            {
                RemoveItem( item );
            }
        }
    }

    void OnItemUse( Item item )
    {
        if ( item is ConsumableItem consumableItem )
        {
            if ( consumableItem.Count <= 0 )
                RemoveItem( consumableItem );
        }
    }

    void OnItemThrow( Item item )
    {
        if ( item.Count <= 0 )
        {
            RemoveItem( item );
        }
    }
}