using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    UIMainMenu uiMainMenu;
    Inventory inventory;
    public Sprite[] itemImages = new Sprite[7];
    // Start is called before the first frame update
    void Start()
    {
        SetData();
        SetInventory();
    }

    // 珥덇린 ?뚮젅?댁뼱 ?명똿
    void SetData()
    {
        uiMainMenu = GameObject.FindGameObjectWithTag("UIMainMenu").GetComponent<UIMainMenu>();
        inventory = GameObject.FindGameObjectWithTag("UIInventory").GetComponent<Inventory>();

        Character character = new Character("코딩 노예", "Chad",
        "코딩의 노예가 된지 10년짜리 되는 머습입\r\n니다. " +
        "오늘도 밤샐일만 남아서 치킨을 시킬\r\n지도 모른다는 생각에" +
        " 배민을 키고 있네요.", 10, 9, 20000, 35, 40, 100, 25);

        GameManager.Instance.SetCharacter(character);
 
        uiMainMenu.SettingPlayerInfo(character);
    }
    // 珥덇린 ?몃깽?좊━ ?명똿
    void SetInventory()
    {
        List<Item> itemList = new List<Item>() { 
      //   new EquipItem("移?, ItemType.Equip, itemImages[0], 1, 99, EquipType.Weapon ),
     //    new EquipItem("?붿궡", ItemType.Equip, itemImages[1], 1, 99, EquipType.Weapon ),
      //     new EquipItem("移?, ItemType.Equip, itemImages[0], 1, 99, EquipType.Weapon )

        };
    }
}
