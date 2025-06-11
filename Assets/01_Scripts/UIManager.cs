using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum UIType
{
    MainMenu,
    Status,
    Inventory,
}
// Lazy Initialization : Singleton 패턴에서 인스턴스가 필요할 때까지 초기화를 연기하는 방법
// sealed : 상속 불가
public sealed class UIManager : MonoBehaviour
{
    private static UIManager _instance = null;

    [SerializeField] private GameObject uiMainMenu;
    [SerializeField] private GameObject uiStatus;
    [SerializeField] private GameObject uiInventory;

    private Dictionary<UIType, GameObject> uiDic = new Dictionary<UIType, GameObject>();
    private UIType currentUI = UIType.MainMenu;
    
    UIInventory _uiInventory;
    UIMainMenu _uiMainMenu;

    // Lazy Singleton
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<UIManager>();
            return _instance;  
        }
    }
    private void Awake()
    {
        // 중복 인스턴스가 있으면 삭제
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        _uiInventory = uiInventory.GetComponent<UIInventory>();
        _uiMainMenu = uiMainMenu.GetComponent<UIMainMenu>();

        // UI 초기화
        InitUI();
        OpenUI(UIType.MainMenu);
    }
    // UI 초기화
    void InitUI()
    {
        uiDic[UIType.MainMenu] = uiMainMenu;
        uiDic[UIType.Status] = uiStatus;
        uiDic[UIType.Inventory] = uiInventory;
    }
    // UI 열기
    void OpenUI(UIType uiType)
    {
        // 현재 열려있는 UI 비활성화
        if (uiDic.ContainsKey(currentUI) && currentUI != UIType.MainMenu)
        {
            uiDic[currentUI].GetComponent<Canvas>().enabled = false;
        }

        currentUI = uiType;

        // 새 UI 열기
        if (uiDic.ContainsKey(uiType))
        {
            uiDic[uiType].GetComponent<Canvas>().enabled = true;
           
            // 인벤토리면 슬롯에 아이템 넣어주기
            if(uiType == UIType.Inventory)
            {
                _uiInventory.UpdateSlot();
            }
        }
        else
        {
            Debug.Log("화면이 존재하지 않습니다.");
        }

        // MainMenu의 버튼들(status,inventory) 활성화 여부 조정
        bool showButtons = (uiType == UIType.MainMenu);
        _uiMainMenu.statusButton.gameObject.SetActive(showButtons);
        _uiMainMenu.inventoryButton.gameObject.SetActive(showButtons);
    }

    public void OpenMainMenu() 
    {
        OpenUI(UIType.MainMenu);
    }
    public void OpenStatus()
    { 
        OpenUI(UIType.Status);
    }
    public void OpenInventory()
    {
        OpenUI(UIType.Inventory);
    }
}
