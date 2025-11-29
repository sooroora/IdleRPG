using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [ SerializeField ] private Image itemIcon;
    [ SerializeField ] private TextMeshProUGUI textItemCount;

    [ SerializeField ] Color defaultColor = Color.white;
    [ SerializeField ] Color selectedColor = Color.yellow;

    private Image slotImg;

    public Item Item => item;
    Item item;

    private IItemSlotList itemSlotList;
    private Button itemSlotButton;
    
    //private bool isSelected = false;

    private void Awake()
    {
        slotImg = GetComponent< Image >();
        itemSlotButton = GetComponent< Button >();
        itemSlotList = GetComponentInParent< IItemSlotList >();

        itemSlotButton.onClick.AddListener( OnSelect );

        if ( item == null )
        {
            itemIcon.enabled = false;
            textItemCount.text = "";
        }

        OnDeselect();
    }

    public void SetItemData( Item _item )
    {
        item = _item;

        if ( item == null )
        {
            ClearSlot();
            return;
        }

        ItemData data = ItemManager.Instance.GetItemData( item.Name );

        if ( data == null )
        {
            ClearSlot();
            return;
        }

        itemIcon.enabled = true;
        itemIcon.sprite = data.Icon;

        if ( data.CanStack )
        {
            textItemCount.text = item.Count.ToString();
        }
        else
        {
            textItemCount.text = "";
        }
    }

    public void OnSelect()
    {
        //isSelected = true;
        slotImg.color = selectedColor;

        itemSlotList.SelectItemSlot( this );
    }

    public void OnDeselect()
    {
        slotImg.color = defaultColor;
    }

    public void ClearSlot()
    {
        itemIcon.enabled = false;
        textItemCount.text = "";
    }
}