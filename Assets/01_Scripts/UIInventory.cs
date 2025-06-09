using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
public class UIInventory : MonoBehaviour
{
    public int slotCount = 15;

    public Button closeButton;
    public GameObject uiSlotPrefab;

    public List<EquipItem> equipItems = new List<EquipItem>(); // 플레이어가 장착 중인 아이템들
    public List<UISlot> slots = new List<UISlot>();
    public List<Sprite> itemImages = new List<Sprite>();
    public List<Item> items = new List<Item>();

    public Transform slotsParent;

    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(UIManager.Instance.OpenMainMenu);
        InitInventoryUI();
        SetInventrory();
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
    // 인벤토리 초기 설정
    void SetInventrory()
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
    // 인벤토리의 슬롯 업데이트
    public void UpdateSlot()
    {
        int itemsCount = GameManager.Instance.Character.inventory.Count;

        for (int i = 0; i < itemsCount; i++)
        {
            int index = GameManager.Instance.Character.inventory[i].InventroyIndex;
             slots[index].RefreshUI(GameManager.Instance.Character.inventory[i]);     
        }
    }
    // 아이템 생성
    public List<Item> CreateItem()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].CreateItem(i);
        }
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
    // 특정 아이템을 가진 슬롯 반환
    public UISlot ReturnItemSlot(string itemName)
    {
        return slots.FirstOrDefault(slot => slot.Item != null && slot.Item.ItemName == itemName);
    }
}
