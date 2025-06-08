using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None,
    Equip
}
public class Item  
{
    [SerializeField] protected string itemName;
    [SerializeField] protected ItemType type;
    [SerializeField] protected Sprite image;
    [SerializeField] protected int count;

    public string ItemName {get; private set;}
    public ItemType Type { get; private set;}   
    public Sprite Image { get; private set;}   
    public int Count { get; private set;}

    public Item (string _itemName, ItemType _itemType, Sprite _image, int _count)
    {
        ItemName = _itemName;
        Type = _itemType;
        Image = _image;
        Count = _count;
    }
    public virtual void Use(Character character)
    {

    }
}
