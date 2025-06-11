using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEditor.Progress;
using System.Linq;
public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance = null;

    UIInventory uIInventory;
    public List<Item> items = new List<Item>();
    public List<EquipItem> equipItems = new List<EquipItem>(); // 플레이어가 장착 중인 아이템들

    public static InventoryManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        // 중복 인스턴스가 있으면 삭제
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
        uIInventory = GetComponent<UIInventory>();
        
    }
    // 인벤토리 초기 설정 (시작시 생성된 아이템들 슬롯에 넣어놓기)
    public void SetInventory()
    {
        int itemsCount = GameManager.Instance.Character.inventory.Count;

        for (int i = 0; i < itemsCount; i++)
        {
            uIInventory.slots[i].RefreshUI(GameManager.Instance.Character.inventory[i]);
        }
        for (int i = itemsCount; i < uIInventory.slots.Count; i++)
        {
            uIInventory.slots[i].RemoveItem();
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
        if (index < 0 || index >= uIInventory.slots.Count) return;

        if (uIInventory.slots[index].Item != null)
        {
            uIInventory.slots[index].UseItem();

        }
    }
    // 아이템 장착
    public void Equip(Character character, EquipItem equipItem)
    {
        // 이미 장착 중인 장비들 중에서
        for (int i = 0; i < equipItems.Count; i++)
        {
            // 같은 장비 타입이 있는지 확인
            if (equipItem.EquipType == equipItems[i].EquipType && equipItem.ItemName != equipItems[i].ItemName)
            {
                // 있다면 그 아이템의 슬롯의 장착을 해제한다.
                UISlot slot = ReturnItemSlot(equipItems[i].ItemName); 
                slot.Equip(false);

                // 장착 장비 리스트에서 제거함
                equipItems.RemoveAt(i);
                break;
            }
        }

        // 장착
        UISlot _slot = ReturnItemSlot(equipItem.ItemName);
        _slot.Equip(true);
        character.Equip(equipItem.AttackBonus, equipItem.DefenseBonus, equipItem.HpBonus, equipItem.CriticalHitBonus);
        equipItems.Add(equipItem);

    }
    // 아이템 장착 해제
    public void UnEquip(Character character, EquipItem equipItem)
    {
        character.UnEquip(equipItem.AttackBonus, equipItem.DefenseBonus, equipItem.HpBonus, equipItem.CriticalHitBonus);
    }
    // 특정 아이템을 가진 슬롯 반환
    public UISlot ReturnItemSlot(string itemName)
    {
        return uIInventory.slots.FirstOrDefault(slot => slot.Item != null && slot.Item.ItemName == itemName);
    }
   
}
