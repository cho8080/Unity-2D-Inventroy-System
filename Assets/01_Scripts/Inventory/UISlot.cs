using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Profiling.RawFrameDataView;
using static UnityEditor.Progress;


public class UISlot : MonoBehaviour
{
    Slot slot;

    [SerializeField] private Image itemImage;
    [SerializeField] private Text itemText;

    public Image ItemImage => itemImage;
    public Text ItemText => itemText;

    public void Init(Slot slot)
    {
        this.slot = slot;
    }
    // 슬롯 정보 업데이트
    public void UpdateSlot()
    {
        if (slot.Item == null) { ClearSlot(); return; }
        itemImage.enabled = true;
        itemImage.sprite = slot.Item.Image;
        itemText.text = slot.Item.Count.ToString();
    }
    // 슬롯 비우기
    public void ClearSlot()
    {
        itemImage.sprite = null;
        itemImage.enabled = false;
       
        itemText.text = "";
    }
    // 슬롯 아웃라인 관리
    public void SlotOutline(bool value)
    {
        SlotEvent slotEvent = GetComponent<SlotEvent>();
        slotEvent.outline.enabled = value;
    }
}
