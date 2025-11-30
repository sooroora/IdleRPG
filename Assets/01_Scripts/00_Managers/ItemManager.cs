using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager : SceneSingletonManager<ItemManager>
{
    [SerializeField] private ItemData[] itemData;
    

    private Dictionary<string, ItemData> itemDic;

    public List<ItemData> AllItemData => itemData.ToList();
    
    protected override void Init()
    {
        itemDic = new Dictionary<string, ItemData>();

        foreach (ItemData itemData in itemData)
        {
            itemDic.Add(itemData.name, itemData);
        }
    }

    public ItemData GetItemData(string itemName)
    {
        if (itemDic.ContainsKey(itemName))
        {
            return itemDic[itemName];
        }
        return null;
    }

    public Item NewItem( string itemName )
    {
        if ( itemDic.ContainsKey( itemName ) )
        {
            return itemDic[ itemName ].NewItem();
        }
        return null;
    }
}
