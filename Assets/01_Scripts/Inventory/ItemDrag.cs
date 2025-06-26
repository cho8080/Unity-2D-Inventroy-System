using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;
public static class DragData
{
    public static Item draggedItem;
    public static Slot originSlot;
}
public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Slot slot;
    public Image dragitemImage; 
    Vector3 startPosition;
    Transform startParent;

    void OnEnable()
    {
        slot = GetComponent<Slot>();
    }
    // 드래그 시작시
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (slot == null || slot.Item == null) return;

        // 아이템과 슬롯 임시 저장
        DragData.draggedItem = slot.Item;
        DragData.originSlot = slot;

        // 드래그 이미지 활성화
        dragitemImage = GameObject.FindGameObjectWithTag("DragImage").GetComponent<Image>();
        dragitemImage.enabled = true;
        dragitemImage.sprite = slot.Item.Image;

        // 드래그 이미지 위로
        startParent = dragitemImage.transform.parent;
        dragitemImage.transform.SetParent(GameObject.FindGameObjectWithTag("UIInventory").transform);
        dragitemImage.GetComponent<Image>().raycastTarget = false;
       
        // 드래그 이동
        startPosition = dragitemImage.transform.position;
    }
    // 드래그 중
    public void OnDrag(PointerEventData eventData)
    {
        if (slot == null || slot.Item == null) return;

        // 드래그 이동
        dragitemImage.transform.position = Input.mousePosition;
    }
    // 드래그 끝
    public void OnEndDrag(PointerEventData eventData)
    {
        if (DragData.draggedItem == null || DragData.originSlot == null) return;
        // 드래그 원래 위치로
        dragitemImage.transform.position = startPosition;
        dragitemImage.transform.SetParent(startParent);

        // 드래그 비활성화
        dragitemImage.GetComponent<Image>().raycastTarget = true;
        dragitemImage.enabled = false;

        // 임시 데이터 비우기
        DragData.draggedItem = null;
        DragData.originSlot = null;

    }

}
