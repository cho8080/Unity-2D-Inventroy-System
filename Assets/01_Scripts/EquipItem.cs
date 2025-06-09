using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.TextCore.Text;

public enum EquipType
{
    Weapon,
    Helmet,
    SubWeapon,
    Accessory
}
[CreateAssetMenu(fileName = "NewItem", menuName = "EquipItem")]
public class EquipItem : Item
{
    [Header("EquipData")]
    [SerializeField] private EquipType equipType;

    [SerializeField] private int attackBonus;
    [SerializeField] private int defenseBonus;
    [SerializeField] private int hpBonus;
    [SerializeField] private int criticalHitBonus;

    public int AttackBonus => attackBonus;
    public int DefenseBonus => defenseBonus;
    public int HpBonus => hpBonus;
    public int CriticalHitBonus => criticalHitBonus;

    public override void Use(Character character)
    {
        Equip(character);
    }
    void Equip(Character character)
    {
        UIInventory uIInventory = GameObject.FindGameObjectWithTag("UIInventory").GetComponent<UIInventory>();

        // 이미 장착 중인 장비들 중에서
        for (int i = 0; i < uIInventory.equipItems.Count; i++)
        {
            // 같은 장비 타입이 있는지 확인
            if (equipType == uIInventory.equipItems[i].equipType && itemName != uIInventory.equipItems[i].itemName)
            {
                // 있다면 그 아이템의 슬롯의 장착을 해제한다.
                UISlot slot = uIInventory.ReturnItemSlot(uIInventory.equipItems[i].itemName);;
                slot.Equip(false);

                // 장착 장비 리스트에서 제거함
                uIInventory.equipItems.RemoveAt(i);
                break;
            }
        }

        // 장착
        UISlot _slot = uIInventory.ReturnItemSlot(itemName);
        _slot.Equip(true);
        character.Equip(attackBonus, defenseBonus, hpBonus, criticalHitBonus);
        uIInventory.equipItems.Add(this);

    }
    public void UnEquip(Character character)
    {
        character.UnEquip( attackBonus, defenseBonus, hpBonus, criticalHitBonus);
    }
}
