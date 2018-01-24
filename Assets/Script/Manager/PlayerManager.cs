using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public static PlayerManager instance;

    public enum DEVICE_LANGUAGE
    {
        EN, KR, JP, CN, CNT
    }

    public DEVICE_LANGUAGE LANGUAGE;


    #region STATS

	private readonly float DEFAULT_TRADE    = 1.0f;
    private readonly int DEFAULT_BAG_SIZE   = 6;
    private readonly int DEFAULT_LUCK       = 0;

	private readonly float TRADE_GROWTH     = 0.1f;
    private readonly int BAG_SIZE_GROWTH    = 1;
    private readonly int LUCK_GROWTH        = 1;

    #endregion


    #region KEY

    private readonly string COOKIE = "0b16b6d29f92bc32f417f14f2c16ea2a";
    private readonly string TRADE = "3a5373f7c1598b9e251273833f5bca21";
    private readonly string BAG_SIZE = "32510ca559c0ecdffe8438199b20c85a";

    private readonly string LUCK = "01de7201c286a45d623e47cf81a20c6c";

    #endregion


    private void Awake()
    {
        if (instance == null) instance = this;
        CheckLanguage();
        CheckCookie();
    }

    private void CheckLanguage(){
        if (Application.systemLanguage == SystemLanguage.English)
        {
            LANGUAGE = DEVICE_LANGUAGE.EN;
        }
        else if (Application.systemLanguage == SystemLanguage.Korean)
        {
            LANGUAGE = DEVICE_LANGUAGE.KR;
        }
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			LANGUAGE = DEVICE_LANGUAGE.JP;
		}
        else if (Application.systemLanguage == SystemLanguage.ChineseSimplified)
        {
            LANGUAGE = DEVICE_LANGUAGE.CN;
        }
        else if (Application.systemLanguage == SystemLanguage.ChineseTraditional)
        {
            LANGUAGE = DEVICE_LANGUAGE.CNT;
        }
        else
        {
            LANGUAGE = DEVICE_LANGUAGE.EN;
        }
    }

    private void CheckCookie(){
        if(PlayerPrefs.HasKey(COOKIE)){
            // Already
        }
        else {
            // New user
            PlayerPrefs.SetInt(COOKIE, 1);
            PlayerPrefs.SetFloat(TRADE, DEFAULT_TRADE);
            PlayerPrefs.SetInt(BAG_SIZE, DEFAULT_BAG_SIZE);
            PlayerPrefs.SetInt(LUCK, DEFAULT_LUCK);
        }
    }


    #region GETTER

    public float GetStatsTrade(){
        return PlayerPrefs.GetFloat(TRADE);
    }
    public int GetStatsBagSize(){
        return PlayerPrefs.GetInt(BAG_SIZE);
    }
    public int GetStatsLuck(){
        return PlayerPrefs.GetInt(LUCK);
    }

    #endregion


    #region SETTER

    public void SetStatsTrade(){
		PlayerPrefs.SetFloat(TRADE, GetStatsTrade() + TRADE_GROWTH);
	}
	public void SetStatsBagSize(){
        PlayerPrefs.SetInt(BAG_SIZE, GetStatsBagSize() + BAG_SIZE_GROWTH);
	}
    public void SetStatsLuck(){
        PlayerPrefs.SetInt(LUCK, GetStatsLuck() + LUCK_GROWTH);
    }

    #endregion



    public void DebugDeleteAll(){
        PlayerPrefs.DeleteAll();
        Debug.Log("Deleted");
        CheckCookie();
    }
}
