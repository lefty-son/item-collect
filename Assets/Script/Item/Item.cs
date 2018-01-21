using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject {

    #region CONFIG

    private readonly int COMMON_COST_MULTIPLIER = 1;
    private readonly int RARE_COST_MULTIPLIER = 3;
    private readonly int LEGENDARY_COST_MULTIPLIER = 12;
    private readonly int ANCIENT_COST_MULTIPLIER = 60;

    #endregion

    #region PROP

    public string id;
    public string enName, enDesc;
    public string krName, krDesc;
    public string cnName, cnDesc;
    public string jpName, jpDesc;
    public string cntName, cntDesc;
    public int defaultCost;
    public int sellingCost;
    public enum Rarity { COMMON, RARE, LEGENDARY, ANCIENT }
    public Rarity rarity;
    public Sprite sprite;

    #endregion

    public void SetCommon(){
        rarity = Rarity.COMMON;
        sellingCost = defaultCost * COMMON_COST_MULTIPLIER;
    }

    public void SetRare(){
        rarity = Rarity.RARE;
        sellingCost = defaultCost * RARE_COST_MULTIPLIER;
    }

    public void SetLegendray(){
        rarity = Rarity.LEGENDARY;
        sellingCost = defaultCost * LEGENDARY_COST_MULTIPLIER;
    }

    public void SetAncient(){
        rarity = Rarity.ANCIENT;
        sellingCost = defaultCost * ANCIENT_COST_MULTIPLIER;
    }

    public void SetTextEN(string _name, string _desc){
        enName = _name;
        enDesc = _desc;
    }

    public void SetTextKR(string _name, string _desc)
    {
        krName = _name;
        krDesc = _desc;
    }

    public void SetTextCN(string _name, string _desc)
    {
        cnName = _name;
        cnDesc = _desc;
    }

    public void SetTextJP(string _name, string _desc)
    {
        jpName = _name;
        jpDesc = _desc;
    }

    public void SetTextCNT(string _name, string _desc)
    {
        cntName = _name;
        cntDesc = _desc;
    }

    public string GetNameNative(){
        if (Application.systemLanguage == SystemLanguage.English) {
            return enName;
        }
        else if(Application.systemLanguage == SystemLanguage.Korean){
            return krName;
        }
        else if (Application.systemLanguage == SystemLanguage.ChineseSimplified)
        {
            return cnName;
        }
        else if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            return jpName;
        }
        else if (Application.systemLanguage == SystemLanguage.ChineseTraditional)
        {
            return cntName;
        }
        else {
            return enName;
        }
    }

    public string GetDescNative(){
        if (Application.systemLanguage == SystemLanguage.English)
        {
            return enDesc;
        }
        else if (Application.systemLanguage == SystemLanguage.Korean)
        {
            return krDesc;
        }
        else if (Application.systemLanguage == SystemLanguage.ChineseSimplified)
        {
            return cnDesc;
        }
        else if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            return jpDesc;
        }
        else if (Application.systemLanguage == SystemLanguage.ChineseTraditional)
        {
            return cntDesc;
        }
        else
        {
            return enDesc;
        }
    }
}
