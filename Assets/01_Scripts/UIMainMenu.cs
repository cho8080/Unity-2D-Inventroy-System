using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMainMenu : MonoBehaviour
{
    public Text alias;
    public Text playerName;
    public Text level;
    public Text money;
    public Text quest;
    public Slider questSlider;
    public Text Introduction;

    public Button statusButton;
    public Button inventoryButton;

    // Start is called before the first frame update
    void Awake()
    {
        UIManager.Instance.OpenMainMenu();
        statusButton.onClick.AddListener (UIManager.Instance.OpenStatus);
        inventoryButton.onClick.AddListener(UIManager.Instance.OpenInventory);
    }

    public void SettingPlayerInfo(Character character)
    {
        alias.text = character.Alias;
        playerName.text = character.PlayerName;
        level.text = character.Level.ToString();
        money.text = character.Money.ToString();
        quest.text =$"{ character.Quest.ToString()} / 12";
        questSlider.value = character.Quest;
        Introduction.text = character.Introduction;
    }
}
