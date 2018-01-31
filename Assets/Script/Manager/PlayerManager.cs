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
    private readonly int DEFAULT_BAG_SIZE   = 6;


    #region KEY

    private readonly string COOKIE = "0b16b6d29f92bc32f417f14f2c16ea2a";

    private readonly string TRADE_LEVEL = "3a5373f7c1598b9e251273833f5bca21";
    private readonly string PERSUASION_LEVEL = "8ab217095857bd6030720149cba0761c";
    private readonly string BAG_SIZE_LEVEL = "32510ca559c0ecdffe8438199b20c85a";
    private readonly string LUCK_LEVEL = "01de7201c286a45d623e47cf81a20c6c";

    private readonly string LOCATION = "71233d73cc90bba8f4d5bbea0792e551";

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

            CurrencyManager.instance.InitGold();

            PlayerPrefs.SetInt(TRADE_LEVEL, 0);
            PlayerPrefs.SetInt(PERSUASION_LEVEL, 0);
            PlayerPrefs.SetInt(BAG_SIZE_LEVEL, 0);
            PlayerPrefs.SetInt(LUCK_LEVEL, 0);
            PlayerPrefs.SetInt(LOCATION, 0);
        }
    }


    #region GETTER

    public int GetStatsTradeLevel(){
        return PlayerPrefs.GetInt(TRADE_LEVEL);
    }
    public int GetStatsPersuasionLevel(){
        return PlayerPrefs.GetInt(PERSUASION_LEVEL);
    }
    public int GetStatsBagSizeLevel(){
        return PlayerPrefs.GetInt(BAG_SIZE_LEVEL);
    }
    public int GetStatsLuckLevel(){
        return PlayerPrefs.GetInt(LUCK_LEVEL);
    }

    public float GetStatsTradeValue(){
        var level = GetStatsTradeLevel();
        float trade = 1f - (100f / (float)(100 + level)) * 50f + 50;
        return trade * 0.01f;
    }
    public float GetStatsPersuasionValue(){
        var level = GetStatsPersuasionLevel();
        float persuasion = 1f - (100f / (float)(100 + level)) * 50f + 50;
        return persuasion;
    }
    public int GetStatsBagSizeValue(){
        return GetStatsBagSizeLevel() + DEFAULT_BAG_SIZE;
    }
    public float GetStatsLuckValue(){
        var level = GetStatsLuckLevel();
        float luck = 1f - (100f / (float)(100 + level)) * 50f + 50;
        return  luck;
    }

    public int GetCurrentLocation(){
        return PlayerPrefs.GetInt(LOCATION);
    }

    #endregion



    #region SETTER

    public void SetStatsTradeLevelUp(){
        PlayerPrefs.SetInt(TRADE_LEVEL, GetStatsTradeLevel() + 1);
	}
    public void SetStatsPersuasionLevelUp(){
        PlayerPrefs.SetInt(TRADE_LEVEL, GetStatsPersuasionLevel() + 1);
    }
    public void SetStatsBagSizeLevelUp(){
        PlayerPrefs.SetInt(BAG_SIZE_LEVEL, GetStatsBagSizeLevel() + 1);
	}
    public void SetStatsLuckLevelUp(){
        PlayerPrefs.SetInt(LUCK_LEVEL, GetStatsLuckLevel() + 1);
    }
    public void SetCurrentLocation(int value){
        PlayerPrefs.SetInt(LOCATION, value);
		FindObjectOfType<TextCurrentLocationHolder>().OnEnable();
    }

    #endregion



    public void DebugDeleteAll(){
        PlayerPrefs.DeleteAll();
        Debug.Log("Deleted");
        CheckCookie();
    }
}
