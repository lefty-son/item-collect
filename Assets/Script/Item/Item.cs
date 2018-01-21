using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject {

    #region CONFIG

    private readonly int COMMON_CHANCE = 67;
    private readonly int RARE_CHANCE = 88;
    private readonly int LEGENDARY_CHANCE = 97;

    private readonly int COMMON_COST_MULTIPLIER = 1;
    private readonly int RARE_COST_MULTIPLIER = 3;
    private readonly int LEGENDARY_COST_MULTIPLIER = 12;
    private readonly int ANCIENT_COST_MULTIPLIER = 60;

    #endregion

    #region PROP

    public string id;
    public string EN_Name;
	public string KR_Name;
    public string JP_Name;
    public string Simple_CN_Name;
    public string Traditional_CN_Name;
    public int defaultCost;
    public int sellingCost;
    public enum Rarity { COMMON, RARE, LEGENDARY, ANCIENT }
    public Rarity rarity;
    public Sprite sprite;

    #endregion

    //public void Roll(){
    //    sellingCost = defaultCost;
    //    var r = Random.Range(0, 100);
    //    if(r <= COMMON_CHANCE){
    //        SetCommon();
    //    }
    //    else if(r <= RARE_CHANCE){
    //        SetRare();
    //    }
    //    else if(r <= LEGENDARY_CHANCE){
    //        SetLegendray();
    //    }
    //    else {
    //        SetAncient();
    //    }
    //}

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

}
