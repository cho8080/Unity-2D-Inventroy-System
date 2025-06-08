using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

// Lazy Initialization : Singleton 패턴에서 인스턴스가 필요할 때까지 초기화를 연기하는 방법
// sealed : 상속 불가
public sealed class UIManager : MonoBehaviour
{
    private static UIManager _instance = null;


    [SerializeField] private GameObject uiMainMenu;
    [SerializeField] private GameObject uiStatus;
    [SerializeField] private GameObject uiInventory;


    public GameObject UIMainMenu => uiMainMenu;
    public GameObject UIStatus => uiStatus;
    public GameObject UIInventory => uiInventory;

    void ChangeUIMainMenu(GameObject obj)
    {
        uiMainMenu = obj;
    }

    UIManager() { }

    public static UIManager Instance
    {
        get
        {
            return _instance;  
        }
    }
    private void Awake()
    {
        // 중복 인스턴스가 있으면 삭제 (선택 사항)
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void OpenMainMenu() 
    {
        OpenUI(uiMainMenu);
    }
    public void OpenStatus()
    {
        OpenUI(uiStatus);
    }
    public void OpenInventory()
    {
        OpenUI(uiInventory);
    }
    public void OpenUI(GameObject targetUI)
    {
        bool showButtons = false;

        uiMainMenu.SetActive(true);
       
        if (targetUI == uiStatus ) 
        {
            showButtons = false;
            uiStatus.GetComponent<Canvas>().enabled = true;
        }
        else if(targetUI == uiInventory)
        {
            showButtons = false;
            uiInventory.GetComponent<Canvas>().enabled = true;
            uiInventory.GetComponent<UIInventory>().UpdateSlot();
        }
        else
        {
            showButtons = true;
            uiStatus.GetComponent<Canvas>().enabled = false;
            uiInventory.GetComponent<Canvas>().enabled = false;
        }

        uiMainMenu.GetComponent<UIMainMenu>().statusButton.gameObject.SetActive(showButtons);
        uiMainMenu.GetComponent<UIMainMenu>().inventoryButton.gameObject.SetActive(showButtons);
    }
}
