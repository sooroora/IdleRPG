using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemInfoUI : ItemInfoUI
{
    [ Header( "Buttons" ) ]
    [ SerializeField ] private Button buyButton;


    void Awake()
    {
        buyButton.onClick.AddListener( OnClickBuyButton );
    }

    private void Start()
    {
        GameManager.Instance.PlayerInfo.OnAddGoldAction += UpdateInfo;
    }

    protected override void ShowInfoInternal()
    {
        if ( nowItem == null ) return;

        priceText.text = nowItem.Price.ToString() + "G";

        if ( GameManager.Instance.PlayerInfo.Gold < nowItem.Price )
            buyButton.interactable = false;
        else
            buyButton.interactable = true;
    }

    public void OnClickBuyButton()
    {
        if ( nowItem == null ) return;

        if ( GameManager.Instance.PlayerInfo.Gold >= nowItem.Price )
        {
            Item newItem = ItemManager.Instance.NewItem( nowItem.Name );
            
            if ( GameManager.Instance.PlayerInfo.Inventory.AddItem( newItem ) )
            {
                GameManager.Instance.PlayerInfo.AddGold( -nowItem.Price );
            }
            
        }
        InvokeOnItemButtonAction();
    }

    public void UpdateInfo()
    {
        if( nowItem == null ) return;
        
        if ( GameManager.Instance.PlayerInfo.Gold < nowItem.Price )
            buyButton.interactable = false;
        else
            buyButton.interactable = true;
        
    }
}