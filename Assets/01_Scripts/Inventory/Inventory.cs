using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEditor.Progress;

using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    private static Inventory _instance = null;
    UIInventory uiInventory;
 
    public List<Slot> slots = new List<Slot>();
    public List<Item> items = new List<Item>();

    public int slotCount = 15;
    public GameObject uiSlotPrefab;
    public Transform slotsParent;

    public Button closeButton;

    public static Inventory Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        uiInventory = GetComponent<UIInventory>();

        CreateSlots();  // 슬롯 동적 생성
        SetInventory(); // 인벤토리 초기 설정
    }
    // 슬롯 동적 생성
    void CreateSlots()
    {
        // 초기화
        for (int i = 0; i < slotCount; i++)
        {
            GameObject slot = Instantiate(uiSlotPrefab, slotsParent);
            Slot _slot = slot.GetComponent<Slot>();
            slots.Add(_slot);
            slots[i].slotIndex = i;
            slots[i].Init( this, uiInventory);

            UISlot uISlot = slot.GetComponent<UISlot>();
            uISlot.Init(_slot);
        }

    }
    // 인벤토리 초기 설정
    public void SetInventory()
    {
        for (int i = 0; i < items.Count; i++)
        {
            AddItem(items[i]); // 아이템 넣기                   
        }
        for (int i = items.Count; i < slots.Count; i++)
        {
            ClearSlot(slots[i]); // 나머지 슬롯은 비우기
        }

    }
    // 아이템 넣기
    public void AddItem(Item item)
    {
        Slot exitsSlot = null;

        foreach (var slot in slots)
        {
            // 동일한 아이템이 있다면
            if (slot != null && slot.HasItem(item))
            {
                exitsSlot = slot;
                break;
            }
        }

        if (exitsSlot != null)
        {
            exitsSlot.AddCount(1);
        }
        // 동일한 아이템이 없다면 
        else
        {
            // 슬롯의 빈곳을 찾아서
            Slot emptySlot = FindEmptySlot();
            if (emptySlot == null) { return; }

            // 아이템 넣어주기
            emptySlot.SetItem(item);

            uiInventory.UpdateSlot(emptySlot);
        }

    }
    // 슬롯 비우기
    void ClearSlot(Slot slot)
    {
        slot.Clear();
        uiInventory.UpdateSlot(slot);
    }
    // 빈 슬롯 찾기
    Slot FindEmptySlot()
    {
        Slot emptySlot = null;
        foreach (var slot in slots)
        {
            if (slot.Item == null)
            {
                emptySlot = slot;
                return emptySlot;
            }
        }
        return emptySlot;
    }
    // 해당 아이템의 위치 찾기
    int FindItemPos(Item item)
    {
        int index = -1;
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].Item == item)
            {
                index = i;
                return index;
            }
        }
        return index;
    }
    // 장착 중인 아이템 해제
    public void SetEquipItemSlot(EquipItem equipItem)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == null)
            {
                continue;
            }
            if (items[i] is EquipItem equippedItem)
            {
                // 이미 같은 타입의 아이템을 착용중이라면 교채
                if (equipItem.EquipType == equippedItem.EquipType
                  && equipItem != equippedItem && equippedItem.Equipped)
                {
                    Slot slot = slots[FindItemPos(equippedItem)];
                    UISlot uiSlot = slot.GetComponent<UISlot>();

                    uiInventory.UpdateSlot(slot);
                    equippedItem.UnEquip(); // 장착 해제
                    uiSlot.SlotOutline(equippedItem.Equipped);
                    return;
                }
            }
        }
    }
}
