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

    public EquipType EquipType => equipType;
    public int AttackBonus => attackBonus;
    public int DefenseBonus => defenseBonus;
    public int HpBonus => hpBonus;
    public int CriticalHitBonus => criticalHitBonus;

    public override void Use(Character character)
    {
        InventoryManager.Instance.Equip(character,this);
    }
}
