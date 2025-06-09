using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public enum ItemType
{
    None,
    Equip
}
[CreateAssetMenu(fileName ="NewItem", menuName ="Item")]
public class Item  : ScriptableObject
{
    [Header("Info")]
    [SerializeField] protected string itemName;
    [SerializeField] protected ItemType type;
    [SerializeField] protected Sprite image;
    [SerializeField] protected int inventroyIndex;

    [Header("Stacking")]
    [SerializeField] protected int count;
    [SerializeField] protected int maxCount;

    public string ItemName => itemName;
    public ItemType Type => type;
    public Sprite Image => image;
    public int InventroyIndex => inventroyIndex;
    public int Count => count;
    public int MaxCount => maxCount;

    public virtual void CreateItem(int index)
    {
        inventroyIndex = index;
        if (count == 0) { count = 1; }
    }
    public virtual void Add(int value)
    {
        int result = count + value;
        if(result >= maxCount) {count = maxCount;}
        else { count += value; }
    }
    public virtual void Remove(int value)
    {
        int result = count - value;
        if (result <= 0) { count = 0; }
        else { count -= value; }
    }
    public virtual void Use(Character character)
    {
        UIInventory uIInventory = FindObjectOfType<UIInventory>();
        uIInventory.items.Remove(this);
    }
}
