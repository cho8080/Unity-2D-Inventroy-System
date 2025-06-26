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
    void Start()
    {
        StartCoroutine(Cor());
    }

    IEnumerator Cor()
    {
        closeButton.onClick.AddListener(UIManager.Instance.OpenMainMenu);

        yield return new WaitUntil(() => GameManager.Instance != null && GameManager.Instance.Character != null);

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
