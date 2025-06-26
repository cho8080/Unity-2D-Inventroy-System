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
// Lazy Initialization : Singleton ?�턴?�서 ?�스?�스가 ?�요???�까지 초기?��? ?�기?�는 방법
// sealed : ?�속 불�?
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
        // 중복 ?�스?�스가 ?�으�???��
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

        // UI 초기??
        InitUI();
        OpenUI(UIType.MainMenu);
    }
    // UI 초기??
    void InitUI()
    {
        uiDic[UIType.MainMenu] = uiMainMenu;
        uiDic[UIType.Status] = uiStatus;
        uiDic[UIType.Inventory] = uiInventory;
    }
    // UI ?�기
    void OpenUI(UIType uiType)
    {
        // ?�재 ?�려?�는 UI 비활?�화
        if (uiDic.ContainsKey(currentUI) && currentUI != UIType.MainMenu)
        {
            uiDic[currentUI].GetComponent<Canvas>().enabled = false;
        }

        currentUI = uiType;

        // ??UI ?�기
        if (uiDic.ContainsKey(uiType))
        {
            uiDic[uiType].GetComponent<Canvas>().enabled = true;
           
            // ?�벤?�리�??�롯???�이???�어주기
            if(uiType == UIType.Inventory)
            {
               // _uiInventory.UpdateSlot();
            }
        }
        else
        {
            Debug.Log("?�면??존재?��? ?�습?�다.");
        }

        // MainMenu??버튼??status,inventory) ?�성???��? 조정
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
