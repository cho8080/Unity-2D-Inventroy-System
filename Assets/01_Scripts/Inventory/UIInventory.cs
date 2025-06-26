using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;
public class UIInventory : MonoBehaviour
{
    Inventory inventory;
    public int slotCount = 15;

    public Button closeButton;
    public GameObject uiSlotPrefab;

    public List<Sprite> itemImages = new List<Sprite>();
    public Transform slotsParent;

    [SerializeField] private TMP_InputField searchInput;

    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(UIManager.Instance.OpenMainMenu);
        inventory = GetComponent<Inventory>();
        searchInput.onEndEdit.AddListener(OnSearch);
    }

    // UI 업데이트
    public void UpdateSlot(Slot slot)
    {
        UISlot uiSlot = slot.gameObject.GetComponent<UISlot>();
        uiSlot.UpdateSlot();
    }
    // 검색
    public void OnSearch(string keyword)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // 전체 인벤토리 아이템들 중에 입력값과 같은 것들을 Add
            List<Item> searchItems = inventory.items
             .Where(item => item.ItemName.ToLower().Contains(keyword.ToLower()))
             .ToList();

            inventory.ClearInventory();

            foreach (Item item in searchItems)
            {
                inventory.AddItem(item);
            }

        }
    }

}
