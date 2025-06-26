using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;


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

       
    }
  public void SetCharacter(Character character)
    {
        Character = character;
    }
}
