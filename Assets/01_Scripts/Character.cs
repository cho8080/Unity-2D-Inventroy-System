using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character 
{
    private string alias;
    private string playerName;
    private string introduction; // 소개글
    private int level;
    private int quest;
    private int money;
    private float attackPower;
    private float defensePower;
    private float hp;
    private float criticalHit; // 치명타

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
                    float _attackPower, float _defensePower, float _hp, float _criticalHit, List<Item> _inventory)
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
        inventory = _inventory;
    }
    // 아이템 추가
    public void Additem(Item item)
    {
        inventory.Add(item);
    }
    // 착용
    public void Equip(float value01, float value02, float value03, float value04)
    {
        AttackPower += value01;
        DefensePower += value02;
        Hp += value03;
        CriticalHit += value04;
    }
    // 벗기
    public void UnEquip(float value01, float value02, float value03, float value04)
    {
        AttackPower -= value01;
        DefensePower -= value02;
        Hp -= value03;
        CriticalHit -= value04;
    }
}
