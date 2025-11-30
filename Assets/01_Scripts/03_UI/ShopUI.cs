using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : BottomMenuUI,IItemSlotList
{
   [ SerializeField ] protected ItemSlotUI itemSlotUIPrefab;
   [ SerializeField ] protected Transform itemSlotContent;
   [ SerializeField ] protected private ShopItemInfoUI itemInfoUI;

   private List<Item> sellItems;
   protected List< ItemSlotUI > itemSlots;
   protected ItemSlotUI nowSelectedSlot;
   
   
   public override void Init()
   {
      itemSlots = new List< ItemSlotUI >();
      sellItems = new List< Item >();
   }

   private void Start()
   {

      List<ItemData> items = ItemManager.Instance.AllItemData;
      sellItems = new List< Item >();
      
      foreach (ItemData i in items)
      {
         Item newItem = i.NewItem();
         sellItems.Add(newItem);
         
         ItemSlotUI newSlot = Instantiate(itemSlotUIPrefab,itemSlotContent);
         itemSlots.Add(newSlot);

         newSlot.SetItemData(newItem);
         newSlot.HideCountText();

      }
      
      itemInfoUI.HideInfo();

   }

   public void SelectItemSlot(ItemSlotUI slot)
   {
      if ( nowSelectedSlot != null && nowSelectedSlot == slot )
      {
         nowSelectedSlot.OnDeselect();
         itemInfoUI.HideInfo();
         nowSelectedSlot = null;
      }
      else
      {
         if(nowSelectedSlot != null)
            nowSelectedSlot.OnDeselect();
         
         nowSelectedSlot = slot;
         itemInfoUI.ShowInfo(slot.Item);
      }
   }


}
