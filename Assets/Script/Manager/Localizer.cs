using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localizer : MonoBehaviour {
    public static Localizer instance;

    private readonly string item001 = "item001";
	private readonly string item002 = "item003";
    private readonly string item003 = "item002";


    #region RARITY STATIC TRANSLATE

    public static string EN_COMMON = "Common";
    public static string EN_RARE = "Rare";
    public static string EN_LGD = "Legendary";
    public static string EN_ANCIENT = "Ancient";

    public static string KR_COMMON      = "일반";
    public static string KR_RARE        = "희귀";
    public static string KR_LGD         = "전설";
    public static string KR_ANCIENT     = "고대";

    public static string JP_COMMON = "一般";
    public static string JP_RARE = "まれな";
    public static string JP_LGD = "伝説の";
    public static string JP_ANCIENT = "古代";

    public static string CN_COMMON = "共同";
    public static string CN_RARE = "罕见";
    public static string CN_LGD = "传奇的";
    public static string CN_ANCIENT = "古";

    public static string CNT_COMMON = "共同";
    public static string CNT_RARE = "罕見";
    public static string CNT_LGD = "傳奇的";
    public static string CNT_ANCIENT = "古";

    #endregion


    private Dictionary<string, string> dict;

    private void Awake()
    {
        if (instance == null) instance = this;
        dict = new Dictionary<string, string>();
        FillDictionary();
    }

    private void FillDictionary(){
        dict.Add(item001, "Sword");
        dict.Add(item002, "Knife");
        dict.Add(item003, "Dagger");
    }

    public string GetTextFromLocal(string _key)
    {
        return dict[_key];
    }

    public static string GetENRarity(Item item){
        if(item.rarity == Item.Rarity.COMMON){
            return EN_COMMON;
        }
        else if(item.rarity == Item.Rarity.RARE){
            return EN_RARE;
        }
        else if (item.rarity == Item.Rarity.LEGENDARY)
        {
            return EN_LGD;
        }
        else{
            return EN_ANCIENT;
        }
    }

    public static string GetKRRarity(Item item)
    {
        if (item.rarity == Item.Rarity.COMMON)
        {
            return KR_COMMON;
        }
        else if (item.rarity == Item.Rarity.RARE)
        {
            return KR_RARE;
        }
        else if (item.rarity == Item.Rarity.LEGENDARY)
        {
            return KR_LGD;
        }
        else
        {
            return KR_ANCIENT;
        }
    }

    public static string GetJPRarity(Item item)
    {
        if (item.rarity == Item.Rarity.COMMON)
        {
            return JP_COMMON;
        }
        else if (item.rarity == Item.Rarity.RARE)
        {
            return JP_RARE;
        }
        else if (item.rarity == Item.Rarity.LEGENDARY)
        {
            return JP_LGD;
        }
        else
        {
            return JP_ANCIENT;
        }
    }

    public static string GetCNRarity(Item item)
    {
        if (item.rarity == Item.Rarity.COMMON)
        {
            return CN_COMMON;
        }
        else if (item.rarity == Item.Rarity.RARE)
        {
            return CN_RARE;
        }
        else if (item.rarity == Item.Rarity.LEGENDARY)
        {
            return CN_LGD;
        }
        else
        {
            return CN_ANCIENT;
        }
    }

    public static string GetCNTRarity(Item item)
    {
        if (item.rarity == Item.Rarity.COMMON)
        {
            return CNT_COMMON;
        }
        else if (item.rarity == Item.Rarity.RARE)
        {
            return CNT_RARE;
        }
        else if (item.rarity == Item.Rarity.LEGENDARY)
        {
            return CNT_LGD;
        }
        else
        {
            return CNT_ANCIENT;
        }
    }
}
