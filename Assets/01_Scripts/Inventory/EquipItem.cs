using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.TextCore.Text;
using static UnityEditor.Progress;

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
    [SerializeField] private bool equipped; // ?λ퉬 ?μ갑 ?щ?

    public EquipType EquipType => equipType;
    public int AttackBonus => attackBonus;
    public int DefenseBonus => defenseBonus;
    public int HpBonus => hpBonus;
    public int CriticalHitBonus => criticalHitBonus;
    public bool Equipped => equipped;

    public static event Action<EquipItem> OnEquipRequested; 

    public EquipItem( int _count, int _maxCount , EquipType _equipType, 
        int attackBonus, int defenseBonus,int hpBonus, int criticalHitBonus)   
     : base( _count, _maxCount)
    {
        equipType = _equipType;
    }

    //public override void Init(Inventory _inventory, UIInventory _uiInventory)
    //{
    //    inventory = _inventory;
    //    uiInventory = _uiInventory;

    //}

    public override void Use()
    {  
        // 이미 장착 중이라면
        if (equipped)
        {
            UnEquip();

        }
        else
        {

            Equip();
        }


    }
    void Equip()
    {
        equipped = true;
        GameManager.Instance.Character.Equip(this);

        UIStatus uIStatus = GameObject.FindGameObjectWithTag("UIStatus").GetComponent<UIStatus>();
        uIStatus.SetStatus();
    }
    public void UnEquip()
    {
        equipped = false;
        GameManager.Instance.Character.UnEquip(this);

        UIStatus uIStatus = GameObject.FindGameObjectWithTag("UIStatus").GetComponent<UIStatus>();
        uIStatus.SetStatus();
    }
}
