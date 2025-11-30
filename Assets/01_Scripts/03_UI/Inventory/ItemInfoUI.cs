using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoUI : MonoBehaviour
{
    [ SerializeField ] GameObject infoPanel;

    [ Header( "Item Info" ) ]
    [ SerializeField ] protected TextMeshProUGUI itemNameText;
    [ SerializeField ] protected TextMeshProUGUI itemDescriptionText;
    [ SerializeField ] protected TextMeshProUGUI itemEffectText;
    [ SerializeField ] protected TextMeshProUGUI priceText;
    
    protected Item nowItem;
    public event Action OnItemButtonAction ;


    private void Awake()
    {
        // btnUse.onClick.AddListener( OnClickUseItem );
        // btnEquip.onClick.AddListener( OnClickEquipItem );
        // btnUnequip.onClick.AddListener( OnClickUnequipItem );
    }
    

    public void ShowInfo( Item item )
    {
        nowItem = item;

        itemNameText.text = item.DisplayName;
        itemDescriptionText.text = item.Description;
        itemEffectText.text = "";
        
        infoPanel.SetActive( true );
        
        
        string effectText = "";
        if ( item is EquipItem equipItem )
        {
            
        }
        else if ( item is ConsumableItem consumableItem )
        {
            for ( int i = 0; i < consumableItem.Consumable.Length; ++i )
            {
                if ( i != 0 ) effectText += "\n";
                effectText += GameCommon.ConsumableText[ consumableItem.Consumable[ i ].consumableType ];
                effectText += (" " + consumableItem.Consumable[ i ].amount);

                if ( consumableItem.Consumable[ i ].duration > 0 )
                {
                    effectText += $"({consumableItem.Consumable[ i ].duration}초)";
                }
            }
            itemEffectText.text = effectText;
        }
        
        ShowInfoInternal();
    }

    protected virtual void ShowInfoInternal()
    {
        
    }
    

    public void HideInfo()
    {
        infoPanel.SetActive( false );
    }


    public void OnClickUseItem()
    {
        if ( nowItem == null ) return;

        if ( nowItem is ConsumableItem consumableItem )
        {
            consumableItem.Use( GameManager.Instance.Player );
        }
        
    }


    protected void InvokeOnItemButtonAction()
    {
        OnItemButtonAction?.Invoke();
    }


}