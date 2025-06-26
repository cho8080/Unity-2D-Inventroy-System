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

    // 초기 ?�레?�어 ?�팅
    void SetData()
    {
        uiMainMenu = GameObject.FindGameObjectWithTag("UIMainMenu").GetComponent<UIMainMenu>();
        inventory = GameObject.FindGameObjectWithTag("UIInventory").GetComponent<Inventory>();

        Character character = new Character("�ڵ� �뿹", "Chad",
        "�ڵ��� �뿹�� ���� 10��¥�� �Ǵ� �ӽ���\r\n�ϴ�. " +
        "���õ� ����ϸ� ���Ƽ� ġŲ�� ��ų\r\n���� �𸥴ٴ� ������" +
        " ����� Ű�� �ֳ׿�.", 10, 9, 20000, 35, 40, 100, 25);

        GameManager.Instance.SetCharacter(character);
 
        uiMainMenu.SettingPlayerInfo(character);
    }
    // 초기 ?�벤?�리 ?�팅
    void SetInventory()
    {
        List<Item> itemList = new List<Item>() { 
      //   new EquipItem("�?, ItemType.Equip, itemImages[0], 1, 99, EquipType.Weapon ),
     //    new EquipItem("?�살", ItemType.Equip, itemImages[1], 1, 99, EquipType.Weapon ),
      //     new EquipItem("�?, ItemType.Equip, itemImages[0], 1, 99, EquipType.Weapon )

        };
    }
}
