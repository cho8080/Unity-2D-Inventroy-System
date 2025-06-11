using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

   UIMainMenu uiMainMenu;
   InventoryManager inventory;
   public Character Character { get; private set; }
    
    public static GameManager Instance
    {
        get
        {
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

        SetData();
    }
  // 초기 플레이어 세팅
    void SetData()
    {
        uiMainMenu = GameObject.FindGameObjectWithTag("UIMainMenu").GetComponent<UIMainMenu>();
        inventory =  GameObject.FindGameObjectWithTag("UIInventory").GetComponent<InventoryManager>();
        Character = new Character("코딩 노예", "Chad",
        "코딩의 노예가 된지 10년짜리 되는 머습입\r\n니다. " +
        "오늘도 밤샐일만 남아서 치킨을 시킬\r\n지도 모른다는 생각에" +
        " 배민을 키고 있네요.", 10, 9, 20000, 35, 40, 100, 25, inventory.CreateItem());

        uiMainMenu.SettingPlayerInfo(Character);
    }
}
