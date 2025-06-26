using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Slot : MonoBehaviour, IDropHandler
{
    private Inventory inventory;
    private UISlot uiSlot;
    protected UIInventory uiInventory;

    [SerializeField] private Item item;

    public Item Item => item;

    public int slotIndex;

    public void Init(Inventory _inventory, UIInventory _uiInventory)
    {
        inventory = _inventory;
        uiInventory = _uiInventory;
        uiSlot = GetComponent<UISlot>();
    }
 
    // 아이템 데이터 변경
    public void SetItem(Item _item)
    {
        this.item = _item;
    }
    public void Clear()
    {
        this.item = null;
    }

    // 아이템 개수 증가
    public void AddCount(int amount)
    {
        item.Add(amount);
    }
    // 아이템 사용
    public void UseItem()
    {
        if (item == null) { return; }
        item.Use();

        if(item is EquipItem equip)
        {
            // 장착시 같은 타입의 다른 이름을 가진 아이템이 있다면 장착중인 아이를 장착해제 해줌
            inventory.SetEquipItemSlot(equip);
            uiSlot.SlotOutline(equip.Equipped);
        }

        // 아이템을 전부 사용했다면
        if (Item.Count == 0)
        {
            inventory.items.Remove(item);
            inventory.slots[slotIndex].Clear();
            uiInventory.UpdateSlot(inventory.slots[slotIndex]);
        }

        uiInventory.UpdateSlot(this);   
    }
    // 동일한 아이템이 있는지 관리
    public bool HasItem(Item _item)
    {
        return item == _item;
    }
    // 마우스 드롭이 발생했을 때
    public void OnDrop(PointerEventData eventData)
    {
      Image dragitemImage = GameObject.FindGameObjectWithTag("DragImage").GetComponent<Image>();
        
        if (dragitemImage != null)
        {
            ChangeSlot();
        }
    }
    // 슬롯 변경
    void ChangeSlot()
    {
        if (DragData.draggedItem != null)
        {
            // 아이템 변경
            Item temp = Item;
            SetItem(DragData.draggedItem);
            DragData.originSlot.item = temp;

            // UI 업데이트
            uiSlot.UpdateSlot();
            DragData.originSlot.uiSlot.UpdateSlot();
        }
    }
}
