using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class InventoryUI : BottomMenuUI, IItemSlotList
{
    [Header("Inventory")]
    [ SerializeField ] protected ItemSlotUI itemSlotUIPrefab;
    [ SerializeField ] protected Transform itemSlotContent;
    [ SerializeField ] protected private ItemInfoUI itemInfoUI;


    protected List< ItemSlotUI > itemSlots;
    protected ItemSlotUI nowSelectedSlot;


    public override void Init()
    {
        itemSlots = new List< ItemSlotUI >();


        for (int i = 0; i < GameCommon.InventoryMaxSlot; i++)
        {
            ItemSlotUI newSlot = Instantiate(itemSlotUIPrefab);
            newSlot.transform.SetParent( itemSlotContent );
            itemSlots.Add(newSlot);
        }
        
        itemInfoUI.OnItemButtonAction += UpdateItemSlots;
        
 

    }

    private void OnEnable()
    {
        // OpenInventory();
        // itemInfoUI.HideInfo();
    }

    public void OpenInventory()
    {
        Inventory inventory = GameManager.Instance.PlayerInfo.Inventory;
        
        if ( inventory == null ) return;
        
        for ( int i = 0; i < itemSlots.Count; ++i )
        {
            if ( inventory.Items.Count > i )
            {
                itemSlots[ i ].SetItemData( inventory.Items[ i ] );
            }
            else
            {
                itemSlots[i].SetItemData(null);
            }
            
            itemSlots[i].OnDeselect();
        }
    }

    public void SelectItemSlot( ItemSlotUI slot )
    {
        if ( nowSelectedSlot != null && nowSelectedSlot != slot )
        {
            nowSelectedSlot.OnDeselect();
        }

        nowSelectedSlot = slot;

        if ( slot.Item != null )
        {
            itemInfoUI.ShowInfo( slot.Item );
        }
    }

    public void DeselectItemSlot(ItemSlotUI slot)
    {
        
    }

    public void UpdateItemSlots()
    {
        Inventory inventory = GameManager.Instance.PlayerInfo.Inventory;
        
        if ( inventory == null ) return;
        
        for ( int i = 0; i < itemSlots.Count; ++i ) 
        {
            if ( inventory.Items.Count > i )
            {
                itemSlots[ i ].SetItemData( inventory.Items[ i ] );
            }
            else
            {
                itemSlots[i].SetItemData(null);
            }
        }
        
        if ( nowSelectedSlot.Item == null )
        {
            itemInfoUI.HideInfo();
        }
    }
}