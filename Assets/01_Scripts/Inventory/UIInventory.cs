using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;
public class UIInventory : MonoBehaviour
{
    public int slotCount = 15;

    public Button closeButton;
    public GameObject uiSlotPrefab;

    public List<Sprite> itemImages = new List<Sprite>();
    public Transform slotsParent;

    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(UIManager.Instance.OpenMainMenu);
    }
    // UI 업데이트
    public void UpdateSlot(Slot slot)
    {
        UISlot uiSlot = slot.gameObject.GetComponent<UISlot>();
        uiSlot.UpdateSlot();
    }
}
