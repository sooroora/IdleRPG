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

        useButton.gameObject.SetActive( false );
        sellButton.gameObject.SetActive( false );
        equipButton.gameObject.SetActive( false );
        unequipButton.gameObject.SetActive( false );
    }

    protected override void ShowInfoInternal()
    {
        if ( nowItem == null ) return;
        
        priceText.text = ( nowItem.Price * GameCommon.ResellRate ).ToString();
        
        
    }

    public void OnClickUseButton()
    {
        if ( nowItem == null ) return;
    }

    public void OnClickSellButton()
    {
        if ( nowItem == null ) return;
    }

    public void OnClickEquipButton()
    {
        if ( nowItem == null ) return;
    }

    public void OnClickUnequipButton()
    {
        if ( nowItem == null ) return;
    }
}