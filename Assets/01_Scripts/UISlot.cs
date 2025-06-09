using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Profiling.RawFrameDataView;
using static UnityEditor.Progress;


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
                // 아이템 사용
                ItemReduction();
                break;
            case ItemType.Equip:
                EquipItem(); // 장비 장착
                break;
            default:
                break;
        }
    }
    // 아이템 감소
    public void ItemReduction()
    {
        // 아이템의 개수가 감소
        item.Remove(1);

        if(item.Count == 0)
        {
            // 아이템 사용
            item.Use(GameManager.Instance.Character);
            // 슬롯을 비우기
            RemoveItem();
        }
    }
   public void EquipItem()
    {
        // 장비 장착
        if (!equipped)
        {
            // 장착 여부 변경
            Equip(true);

            // 아이템 사용
             item.Use(GameManager.Instance.Character);
        }
        // 장착 해제
        else
        {
            // 장착 여부 변경
            Equip(false);
            if (item is EquipItem equipItem)
            {
                equipItem.UnEquip(GameManager.Instance.Character);
            }
        }

        // Status에 아이템 정보 반영
        UIStatus uIStatus = GameObject.FindGameObjectWithTag("UIStatus").GetComponent<UIStatus>();
        uIStatus.SetStatus();
    }
    // 장착 여부 변경
    public void Equip(bool value)
    {
        SlotEvent slotEvent = GetComponent<SlotEvent>();
        // 장착 여부 
        equipped = value;
        // 슬롯의 아웃라인 활성화 여부
        slotEvent.outline.enabled = value;

       
    }
}
