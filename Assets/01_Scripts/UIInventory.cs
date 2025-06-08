using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
public class UIInventory : MonoBehaviour
{
    public int slotCount = 15;
    public Button closeButton;
    public GameObject uiSlotPrefab;
    UISlot uiSlot;

    public List<UISlot> slots = new List<UISlot>();
    public List<Sprite> itemImages = new List<Sprite>();

    public Transform slotsParent;

    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(UIManager.Instance.OpenMainMenu);
        InitInventoryUI();
        UpdateSlot();
    }
    // 슬롯 생성
    void InitInventoryUI()
    {
        for (int i = 0; i < slotCount; i++)
        {
            GameObject uiSlot = Instantiate(uiSlotPrefab, slotsParent);
            slots.Add(uiSlot.GetComponent<UISlot>());
            slots[i].slotIndex = i;
        }
    }
    // 인벤토리의 슬롯 업데이트
    public void UpdateSlot()
    {
        int itemsCount = GameManager.Instance.Character.inventory.Count;
     
        for (int i = 0; i < itemsCount; i++)
        {
           slots[i].RefreshUI(GameManager.Instance.Character.inventory[i]);
        }
        for (int i = itemsCount; i < slots.Count; i++)
        {
            slots[i].RemoveItem();
        }
    }
    // 아이템 생성
    public List<Item> CreateItem()
    {
        var items = new List<Item>();

        items.Add(new EquipItem("칼", itemImages[0], 1,5, 2,0,0));
        items.Add(new EquipItem("방패", itemImages[1], 1, 6, 11, 0, 0));
        items.Add(new EquipItem("도끼", itemImages[2], 1, 9, 4, 0, 2));
        items.Add(new EquipItem("화살", itemImages[3], 1, 11, 10, 0, 3));
        items.Add(new Item("책",ItemType.None ,itemImages[4],1));
        items.Add(new EquipItem("투구", itemImages[5], 1, 11, 16, 10, 0));
        items.Add(new EquipItem("반지", itemImages[6], 1, 20, 20, 10, 10));

        return items;
    }
    // 아이템 사용
    public void UseItem(int index)
    {
        if (slots[index].Item != null)
        {
            slots[index].Useitem();
        }    
    }
}
