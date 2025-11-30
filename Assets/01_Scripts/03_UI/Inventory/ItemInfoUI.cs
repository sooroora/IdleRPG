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
        

        // if ( item is EquipItem equipItem )
        // {
        //     btnUse.gameObject.SetActive( false );
        //
        //     if ( equipItem.IsEquip )
        //     {
        //         btnEquip.gameObject.SetActive( false );
        //         btnUnequip.gameObject.SetActive( true );
        //     }
        //     else
        //     {
        //         btnEquip.gameObject.SetActive( true );
        //         btnUnequip.gameObject.SetActive( false );
        //     }
        //
        //     foreach ( InventoryItemInfoText effectInfoText in effectInfoTexts )
        //     {
        //         effectInfoText.HideInfoText();
        //     }
        //
        //     effectInfoTexts[ 0 ]?.ShowInfoText( "공격력", equipItem.Atk.ToString() );
        // }
        // else
        // {
        //     btnUnequip.gameObject.SetActive( false );
        //     btnEquip.gameObject.SetActive( false );
        //
        //     if ( item is ConsumableItem consumableItem )
        //     {
        //         btnUse.gameObject.SetActive( true );
        //
        //         ConsumableEffect[] consumable = consumableItem.Consumable;
        //         for ( int i = 0; i < effectInfoTexts.Length; ++i )
        //         {
        //             if ( consumable.Length > i )
        //             {
        //                 try
        //                 {
        //                     //키 없을 수도 있음~~
        //                     // 템창에 독있는건 안보여줄거임
        //                     effectInfoTexts[ i ].ShowInfoText( GameCommon.ConsumableText[ consumableItem.Consumable[ i ].consumableType ],
        //                                                        consumableItem.Consumable[ i ].amount.ToString() );
        //                 }
        //                 catch
        //                 {
        //                     effectInfoTexts[ i ].HideInfoText();    
        //                 }
        //             }
        //             else
        //             {
        //                 effectInfoTexts[ i ].HideInfoText();
        //             }
        //         }
        //     }
        //     else
        //     {
        //         for ( int i = 0; i < effectInfoTexts.Length; ++i )
        //         {
        //             effectInfoTexts[i].HideInfoText();
        //         }
        //     }
        // }
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

    public void OnClickEquipItem()
    {
        if ( nowItem == null ) return;

        if ( nowItem is EquipItem equipItem )
        {
            //equipItem.Equip( GameManager.Instance.Player );
        }
        
    }

    public void OnClickUnequipItem()
    {
        if ( nowItem == null ) return;
        
        if ( nowItem is EquipItem equipItem )
        {
            //equipItem.Equip( GameManager.Instance.Player );
        }
    }

    protected void InvokeOnItemButtonAction()
    {
        OnItemButtonAction?.Invoke();
    }


}