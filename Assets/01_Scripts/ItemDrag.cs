using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image itemImage;
    Vector3 startPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = itemImage.transform.position; 
    }
    public void OnDrag(PointerEventData eventData)
    {
        itemImage.transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        itemImage.transform.position = startPosition;
    }
}
