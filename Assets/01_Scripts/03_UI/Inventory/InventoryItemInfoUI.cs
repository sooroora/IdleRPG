using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemInfoUI : ItemInfoUI
{
    [ Header( "Buttons" ) ]
    [ SerializeField ] private Button useButton;

    [ SerializeField ] private Button sellButton;
    [ SerializeField ] private Button equipButton;
    [ SerializeField ] private Button unequipButton;
    

    void Awake()
    {
        useButton.onClick.AddListener( OnClickUseButton );
        sellButton.onClick.AddListener( OnClickSellButton );
        equipButton.onClick.AddListener( OnClickEquipButton );
        unequipButton.onClick.AddListener( OnClickUnequipButton );

        HideAllButtons();
    }

    protected override void ShowInfoInternal()
    {
        if ( nowItem == null ) return;
        
        priceText.text = ( nowItem.Price * GameCommon.ResellRate ).ToString();

        HideAllButtons();
        sellButton.gameObject.SetActive(true);
        if ( nowItem is ConsumableItem consumableItem )
        {
            useButton.gameObject.SetActive( true );    
        }
        else if ( nowItem is EquipItem equipItem )
        {
            if(equipItem.IsEquip)
                unequipButton.gameObject.SetActive( true );
            else
            {
                equipButton.gameObject.SetActive( true );
            }
        }
    }

    public void HideAllButtons()
    {
        useButton.gameObject.SetActive( false );
        sellButton.gameObject.SetActive( false );
        equipButton.gameObject.SetActive( false );
        unequipButton.gameObject.SetActive( false );
    }

    public void OnClickUseButton()
    {
        if ( nowItem == null ) return;
        
        nowItem.Use(GameManager.Instance.Player);
        
        InvokeOnItemButtonAction();
    }

    public void OnClickSellButton()
    {
        if ( nowItem == null ) return;
        
        InvokeOnItemButtonAction();
    }

    public void OnClickEquipButton()
    {
        if ( nowItem == null ) return;
        
        InvokeOnItemButtonAction();
    }

    public void OnClickUnequipButton()
    {
        if ( nowItem == null ) return;
    }
}