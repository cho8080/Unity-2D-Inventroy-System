using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character 
{
    private string alias;
    private string playerName;
    private string introduction; // ?뚭컻湲
    private int level;
    private int quest;
    private int money;
    private float attackPower;
    private float defensePower;
    private float hp;
    private float criticalHit; // 移섎챸?

    public string Alias { get; private set; }
    public string PlayerName { get; private set; }
    public string Introduction { get; private set; }
    public int Level { get; private set; }
    public int Quest { get; private set; }
    public int Money { get; private set; }
    public float AttackPower { get; private set; }
    public float DefensePower { get; private set; }
    public float Hp { get; private set; }
    public float CriticalHit { get; private set; }


    public List<Item> inventory = new List<Item>();
 

    public Character(string _alias, string _playerName, string _introduction, int _level, int _quest, int _money,
                    float _attackPower, float _defensePower, float _hp, float _criticalHit)
    {
        Alias = _alias;
        PlayerName = _playerName;
        Introduction = _introduction;
        Level = _level;
        Quest = _quest;
        Money = _money;
        AttackPower = _attackPower;
        DefensePower = _defensePower;
        Hp = _hp;
        CriticalHit = _criticalHit;
    }
    // ?꾩씠??異붽?
    public void Additem(Item item)
    {
        inventory.Add(item);
    }
    // 李⑹슜
    public void Equip(EquipItem equipItem)
    {
        AttackPower += equipItem.AttackBonus;
        DefensePower += equipItem.DefenseBonus;
        Hp += equipItem.HpBonus;
        CriticalHit += equipItem.CriticalHitBonus;
    }
    // 踰쀪린
    public void UnEquip(EquipItem equipItem)
    {
        AttackPower -= equipItem.AttackBonus;
        DefensePower -= equipItem.DefenseBonus;
        Hp -= equipItem.HpBonus;
        CriticalHit -= equipItem.CriticalHitBonus;
    }
}
