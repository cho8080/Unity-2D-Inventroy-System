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
// Lazy Initialization : Singleton ?¨í„´?ì„œ ?¸ìŠ¤?´ìŠ¤ê°€ ?„ìš”???Œê¹Œì§€ ì´ˆê¸°?”ë? ?°ê¸°?˜ëŠ” ë°©ë²•
// sealed : ?ì† ë¶ˆê?
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
        // ì¤‘ë³µ ?¸ìŠ¤?´ìŠ¤ê°€ ?ˆìœ¼ë©??? œ
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

        // UI ì´ˆê¸°??
        InitUI();
        OpenUI(UIType.MainMenu);
    }
    // UI ì´ˆê¸°??
    void InitUI()
    {
        uiDic[UIType.MainMenu] = uiMainMenu;
        uiDic[UIType.Status] = uiStatus;
        uiDic[UIType.Inventory] = uiInventory;
    }
    // UI ?´ê¸°
    void OpenUI(UIType uiType)
    {
        // ?„ì¬ ?´ë ¤?ˆëŠ” UI ë¹„í™œ?±í™”
        if (uiDic.ContainsKey(currentUI) && currentUI != UIType.MainMenu)
        {
            uiDic[currentUI].GetComponent<Canvas>().enabled = false;
        }

        currentUI = uiType;

        // ??UI ?´ê¸°
        if (uiDic.ContainsKey(uiType))
        {
            uiDic[uiType].GetComponent<Canvas>().enabled = true;
           
            // ?¸ë²¤? ë¦¬ë©??¬ë¡¯???„ì´???£ì–´ì£¼ê¸°
            if(uiType == UIType.Inventory)
            {
               // _uiInventory.UpdateSlot();
            }
        }
        else
        {
            Debug.Log("?”ë©´??ì¡´ì¬?˜ì? ?ŠìŠµ?ˆë‹¤.");
        }

        // MainMenu??ë²„íŠ¼??status,inventory) ?œì„±???¬ë? ì¡°ì •
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
