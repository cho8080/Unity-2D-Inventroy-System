using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UISlot : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private ItemType itemType;
    [SerializeField] private Image itemImage;
    [SerializeField] private Text itemText;

    public Item Item => item;
    public Image ItemImage => itemImage;
    public Text ItemText => itemText;

    public int slotIndex;
    public bool equipped;

    public void SetItem(Item _item)
    {
        item = _item;
        itemType = _item.Type;
        itemImage.enabled = true;
        itemImage.sprite = _item.Image;
        itemText.text = _item.Count.ToString();
    }
    // 슬롯 재설정
   public void RefreshUI(Item _item)
    {
        RemoveItem(); // 슬롯을 비우고
        SetItem(_item); // 아이템 세팅
    }
    // 슬롯 비우기
    public void RemoveItem()
    {
        item = null;
        itemImage.sprite = null;
        itemImage.enabled = false;
   
        itemText.text = "";
    }
    // 아이템 사용
    public void Useitem()
    {
        switch (itemType)
        {
            case ItemType.None:
                break;
            case ItemType.Equip:
                EquipItem(); // 장비 장착
                break;
            default:
                break;
        }

    }
 
    void EquipItem()
    {
        SlotEvent slotEvent = GetComponent<SlotEvent>();

        // 장비 장착
        if (!equipped)
        {
            // 슬롯의 아웃라인 활성화
            equipped = true;
            slotEvent.outline.enabled = true;

            item.Use(GameManager.Instance.Character);

            
        }
        // 장착 해제
        else
        {   // 슬롯의 아웃라인 활성화
            equipped = false;
            slotEvent.outline.enabled = false;

            if (item is EquipItem equipItem)
            {
                equipItem.UnEquip(GameManager.Instance.Character);
            }
        }

        // Status에 아이템 정보 반영
        UIStatus uIStatus = FindObjectOfType<UIStatus>();
        uIStatus.SetStatus();
    }
}
