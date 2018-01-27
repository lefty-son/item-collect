using System.Text;
using UnityEngine;

public class Item : ScriptableObject
{

    #region PROP

    public string inventoryId;
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
    public int forgeLevel;

    #endregion


    #region SETTER

    public void SetRarityRamdomly()
    {
        var r = UnityEngine.Random.Range(0, 100);
        if (r <= Farm.COMMON_CHANCE)
        {
            SetCommon();
        }
        else if (r <= Farm.RARE_CHANCE)
        {
            SetRare();
        }
        else if (r <= Farm.LEGENDARY_CHANCE)
        {
            SetLegendray();
        }
        else
        {
            SetAncient();
        }
    }

    public void SetForgeLevelRandomly(){
        forgeLevel = Random.Range(0, 4);
    }

    public void SetCommon()
    {
        rarity = Rarity.COMMON;
        sellingCost = defaultCost * Farm.COMMON_COST_MULTIPLIER;
    }

    public void SetRare()
    {
        rarity = Rarity.RARE;
        sellingCost = defaultCost * Farm.RARE_COST_MULTIPLIER;
    }

    public void SetLegendray()
    {
        rarity = Rarity.LEGENDARY;
        sellingCost = defaultCost * Farm.LEGENDARY_COST_MULTIPLIER;
    }

    public void SetAncient()
    {
        rarity = Rarity.ANCIENT;
        sellingCost = defaultCost * Farm.ANCIENT_COST_MULTIPLIER;
    }

    public void SetTextEN(string _name, string _desc)
    {
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

    #endregion


    #region GETTER

    public int GetSellingCost()
    {
        return sellingCost;
    }

    public string GetNameNative()
    {
        if (PlayerManager.instance.LANGUAGE == PlayerManager.DEVICE_LANGUAGE.EN)
        {
            return enName;
        }
        else if (PlayerManager.instance.LANGUAGE == PlayerManager.DEVICE_LANGUAGE.KR)
        {
            return krName;
        }
        else if (PlayerManager.instance.LANGUAGE == PlayerManager.DEVICE_LANGUAGE.JP)
        {
            return jpName;
        }
        else if (PlayerManager.instance.LANGUAGE == PlayerManager.DEVICE_LANGUAGE.CN)
        {
            return cnName;
        }
        else if (PlayerManager.instance.LANGUAGE == PlayerManager.DEVICE_LANGUAGE.CNT)
        {
            return cntName;
        }
        else
        {
            return enName;
        }
    }

    public string GetDescNative()
    {
        if (PlayerManager.instance.LANGUAGE == PlayerManager.DEVICE_LANGUAGE.EN)
        {
            return enDesc;
        }
        else if (PlayerManager.instance.LANGUAGE == PlayerManager.DEVICE_LANGUAGE.KR)
        {
            return krDesc;
        }
        else if (PlayerManager.instance.LANGUAGE == PlayerManager.DEVICE_LANGUAGE.JP)
        {
            return jpDesc;
        }
        else if (PlayerManager.instance.LANGUAGE == PlayerManager.DEVICE_LANGUAGE.CN)
        {
            return cnDesc;
        }
        else if (PlayerManager.instance.LANGUAGE == PlayerManager.DEVICE_LANGUAGE.CNT)
        {
            return cntDesc;
        }
        else
        {
            return enDesc;
        }
    }

    public string GetRarityNative()
    {
        if (PlayerManager.instance.LANGUAGE == PlayerManager.DEVICE_LANGUAGE.EN)
        {
            return Localizer.GetENRarity(this);
        }
        else if (PlayerManager.instance.LANGUAGE == PlayerManager.DEVICE_LANGUAGE.KR)
        {
            return Localizer.GetKRRarity(this);
        }
        else if (PlayerManager.instance.LANGUAGE == PlayerManager.DEVICE_LANGUAGE.JP)
        {
            return Localizer.GetJPRarity(this);
        }
        else if (PlayerManager.instance.LANGUAGE == PlayerManager.DEVICE_LANGUAGE.CN)
        {
            return Localizer.GetCNRarity(this);
        }
        else if (PlayerManager.instance.LANGUAGE == PlayerManager.DEVICE_LANGUAGE.CNT)
        {
            return Localizer.GetCNTRarity(this);
        }
        else
        {
            return Localizer.GetENRarity(this);
        }
    }

    public string GetNameByForgeLevel()
    {
        var stb = new StringBuilder(GetNameNative());
        stb.Append(" (+");
        stb.Append(forgeLevel);
        stb.Append(")");
        return stb.ToString();
    }

    public int GetCurrentPriceByForgeLevel()
    {
        return ForgeCalculator.GetCurrentPrice(forgeLevel, sellingCost);
    }

    #endregion
}
