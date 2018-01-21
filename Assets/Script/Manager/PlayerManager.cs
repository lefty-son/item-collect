using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public static PlayerManager instance;

    private readonly float TRADE_GROWTH = 0.1f;
    private readonly int DEFAULT_BAG_SIZE = 6;

    private readonly string COOKIE = "0b16b6d29f92bc32f417f14f2c16ea2a";
    private readonly string TRADE = "3a5373f7c1598b9e251273833f5bca21";
    private readonly string BAG_SIZE = "32510ca559c0ecdffe8438199b20c85a";

    private void Awake()
    {
        if (instance == null) instance = this;
        CheckCookie();
    }

    private void CheckCookie(){
        if(PlayerPrefs.HasKey(COOKIE)){
            // Already
        }
        else {
            // New user
            PlayerPrefs.SetInt(COOKIE, 1);
            PlayerPrefs.SetFloat(TRADE, 1.5f);
            PlayerPrefs.SetInt(BAG_SIZE, DEFAULT_BAG_SIZE);
        }
    }

    public float GetStatsTrade(){
        return PlayerPrefs.GetFloat(TRADE);
    }
    public void SetStatsTrade(){
        PlayerPrefs.SetFloat(TRADE, PlayerPrefs.GetFloat(TRADE) + TRADE_GROWTH);
    }

    public int GetStatsBagSize(){
        return PlayerPrefs.GetInt(BAG_SIZE);
    }
    public void SetStatsBagSize(){
        PlayerPrefs.SetInt(BAG_SIZE,PlayerPrefs.GetInt(BAG_SIZE) + 1);
    }

    public void DebugDeleteAll(){
        PlayerPrefs.DeleteAll();
        Debug.Log("Deleted");
        CheckCookie();
    }
}
