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
    

    // public GameObject SpawnDropItem(string itemName, Vector3 position)
    // {
    //     ItemData itemData = GetItemData(itemName);
    //     if(itemData == null) return null;
    //     if(itemData.DropPrefab == null) return null;
    //     
    //     return Instantiate(itemData.DropPrefab, position, Quaternion.identity);
    // }
}
