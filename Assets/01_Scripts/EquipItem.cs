using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class EquipItem : Item
{
    public int attackBonus;
    public int defenseBonus;
    public int hpBonus;
    public int criticalHitBonus;

    public EquipItem(string _itemName, Sprite _image, int count, int atk, int def, int h, int crit)
        : base(_itemName, ItemType.Equip, _image, count)
    {
        this.attackBonus = atk;
        this.defenseBonus = def;
        this.hpBonus = h;
        this.criticalHitBonus = crit;
    }
    public override void Use(Character character)
    {
        character.Equip(attackBonus, defenseBonus, hpBonus, criticalHitBonus);

    }
    public void UnEquip(Character character)
    {
        character.UnEquip(attackBonus, defenseBonus, hpBonus, criticalHitBonus);
    }
}
