using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIStatus : MonoBehaviour
{

    public Text attackPower;
    public Text defensePower;
    public Text hp;
    public Text criticalHit;

    public Button closeButton;

    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(UIManager.Instance.OpenMainMenu);
        SetStatus();
    }

    public void SetStatus()
    {
        attackPower.text = GameManager.Instance.Character.AttackPower.ToString();
        defensePower.text = GameManager.Instance.Character.DefensePower.ToString();
        hp.text = GameManager.Instance.Character.Hp.ToString();
        criticalHit.text = GameManager.Instance.Character.CriticalHit.ToString();
    }
}
