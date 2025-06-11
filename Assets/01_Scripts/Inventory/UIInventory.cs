using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
public class UIInventory : MonoBehaviour
{
    public int slotCount = 15;

    public Button closeButton;
    public GameObject uiSlotPrefab;

    public List<UISlot> slots = new List<UISlot>();
    public List<Sprite> itemImages = new List<Sprite>();
    public Transform slotsParent;

    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(UIManager.Instance.OpenMainMenu);
        InitInventoryUI();
        GetComponent<InventoryManager>().SetInventory();
    }
    // 슬롯 생성
    void InitInventoryUI()
    {
        for (int i = 0; i < slotCount; i++)
        {
            GameObject uiSlot = Instantiate(uiSlotPrefab, slotsParent);
            slots.Add(uiSlot.GetComponent<UISlot>());
            slots[i].slotIndex = i;
        }
    }
   
    // 인벤토리의 슬롯 업데이트
    public void UpdateSlot()
    {
        int itemsCount = GameManager.Instance.Character.inventory.Count;

        for (int i = 0; i < itemsCount; i++)
        {
            int index = GameManager.Instance.Character.inventory[i].InventoryIndex;
             slots[index].RefreshUI(GameManager.Instance.Character.inventory[i]);     
        }
    }   
}
