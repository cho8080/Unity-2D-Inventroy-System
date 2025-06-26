using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public enum ItemType
{
    None,
    Consume,
    Equip
}
[CreateAssetMenu(fileName ="NewItem", menuName ="Item")]
public class Item  : ScriptableObject
{
    [Header("Info")]
    [SerializeField] protected string itemName;
    [SerializeField] protected ItemType type;
    [SerializeField] protected Sprite image;
    [SerializeField] protected int inventoryIndex;

    [Header("Stacking")]
    [SerializeField] protected int count;
    [SerializeField] protected int maxCount;

    public string ItemName => itemName;
    public ItemType Type => type;
    public Sprite Image => image;
  //  public int InventoryIndex => inventoryIndex;
    public int Count => count;
    public int MaxCount => maxCount;
    //public Inventory inventory;
    //public UIInventory uiInventory;

    public Item(int _count, int _maxCount)
    {
        count = _count;
        maxCount = _maxCount;
    }
    //public virtual void Init(Inventory _inventory,UIInventory _uiInventory)
    //{
    //    inventory = _inventory;
    //    uiInventory = _uiInventory;
    //}
    public virtual void CreateItem(int index)
    {
        inventoryIndex = index;
        if (count == 0) { count = 1; }
    }
    public virtual void Add(int value)
    {
        int result = count + value;
        if (result >= maxCount) { count = maxCount; }
        else { count += value; }
    }
    public virtual void Remove(int value)
    {
        int result = count - value;
        if (result <= 0) { count = 0; }
        else { count -= value; }
    }
    public virtual void Use( )
    {
        Remove(1);
    }
}
