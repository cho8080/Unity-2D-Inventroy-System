using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    UISlot uiSlot;
    public Outline outline;
    private bool isMouseOver = false;
    public float doubleClickThreshold = 0.3f; // 더블클릭 간주할 시간 간격
    private float lastClickTime = -1f;

    void OnEnable()
    {
        uiSlot = GetComponent<UISlot>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!uiSlot.equipped) { isMouseOver = false;  }
    }

    void Update()
    {
        if (isMouseOver)
        {
            outline.enabled = true;

            if (Input.GetMouseButtonDown(0)) 
            {
                float timeSinceLastClick = Time.time - lastClickTime;

                // 더블클릭 시 
                if (timeSinceLastClick <= doubleClickThreshold)
                {
              
                    UIInventory inventory =  FindObjectOfType<UIInventory>();
                    
                    // 아이템 사용
                    inventory.UseItem(uiSlot.slotIndex);
                }
                lastClickTime = Time.time;
            }
        }
        else
        {
            outline.enabled = false;
        }
    }
}
