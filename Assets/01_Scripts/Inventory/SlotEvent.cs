using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Slot slot;
    UISlot uiSlot;
    public Outline outline;
    private bool isMouseOver = false;
    public float doubleClickThreshold = 0.3f; 
    private float lastClickTime = -1f;

    void OnEnable()
    {
        slot = GetComponent<Slot>();
        uiSlot = GetComponent<UISlot>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
    }

    void Update()
    {
        if (isMouseOver)
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                float timeSinceLastClick = Time.time - lastClickTime;

                if (timeSinceLastClick <= doubleClickThreshold)
                {
                    Inventory inventory = GameObject.FindGameObjectWithTag("UIInventory").GetComponent<Inventory>();
                    slot.UseItem();
                    uiSlot.UpdateSlot();
                }
                lastClickTime = Time.time;
            }
        }
    }
}
