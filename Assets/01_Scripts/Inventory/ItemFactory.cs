using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    Inventory inventory;
    public List<Item> itemDatas = new List<Item>();

    void Awake()
    {
        inventory = GetComponent<Inventory>();
        for (int i = 0; i < itemDatas.Count; i++)
        {
            inventory.items.Add(CreateEquipItemInstance(itemDatas[i],i));
        }
  
    }

    public Item CreateEquipItemInstance(Item original, int index)
    {
        Item copy = Instantiate(original);
        copy.CreateItem(index);
        return copy;
    }
}
