using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour {



    public static Inventory instance;
    public List<GameItem> inventory;

    private void Awake()
    {
        if (instance == null) instance = this;
        inventory = new List<GameItem>();
        InitializeGameItem();

        DateTime fuck = new DateTime(2000, 01, 01);

        Debug.Log(DateTime.Now.Ticks - fuck.Ticks);
        Debug.Log(fuck.Ticks);
        Debug.Log(DateTime.Now.Ticks);
    }

    private void InitializeGameItem(){
        for (int i = 0; i < PlayerManager.instance.GetStatsBagSizeValue(); i++){
            inventory.Add(new GameItem());
        }
    }

    public void AddItem(List<Item> items){
        if(IsFullWithLeftOver(items.Count)){
            // Partially add items
            ItemShuffle.Shuffle(items);
            var leftOver = PlayerManager.instance.GetStatsBagSizeValue() - GetAllocatedInventory();
			Debug.LogFormat("have {0} and left {1}", GetAllocatedInventory(), leftOver);
            var leftItemIndex = 0;
            foreach(var inv in inventory){
                if(leftItemIndex == leftOver){
                    break;
                }
                if(!inv.isAllocated){
                    inv.OverwriteInstance(items[leftItemIndex]);
                    leftItemIndex++;
                }
            }
        }
        else {
            var getItemIndex = 0;
            foreach(var inv in inventory){
                if(getItemIndex==items.Count){
                    break;
                }

                if(!inv.isAllocated){
                    inv.OverwriteInstance(items[getItemIndex]);
                    getItemIndex++;
                }
            }
           
        }
    }

    private void PushAndSortInventory(){
        inventory.Sort(
        delegate (GameItem item1, GameItem item2) {
            return item1.timeStamp.CompareTo(item2.timeStamp);
        }
        );
    }

    public void SellAllItems(){
        var revenue = 0;
        foreach(var item in inventory){
            revenue += item.sellingCost;
        }
        inventory.Clear();
    }

    public void DeleteItem(GameItem item){
        var removeIndex = inventory.IndexOf(item);
        inventory[removeIndex].ClearInstance();
        PushAndSortInventory();
        InventoryUIListener.instance.NotifyToSlots();
    }

    public bool IsFull(){
        if(GetAllocatedInventory() > PlayerManager.instance.GetStatsBagSizeValue()){
            return true;
        }
        else {
            return false;
        }
    }

    public bool IsFullWithLeftOver(int count){
        if (GetAllocatedInventory() + count > PlayerManager.instance.GetStatsBagSizeValue())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private int GetAllocatedInventory(){
        var count = 0;
        foreach(var inv in inventory){
            if(inv.isAllocated){
                count++;
            }
        }
        return count;
    }

    //public GameItem GetLastItem(){
        
    //    for (int i = 0; i < inventory.Count;i++){
    //        if(!inventory[i].isAllocated){
    //            return inventory[i - 1];
    //        }
    //    }
    //    return inventory[inventory.Count - 1];
    //}



}

[System.Serializable]
public class GameItem
{
    public string uid;
    public long timeStamp;
    public string id;
    public string nameNative;
    public string rarityNative;
    public int defaultCost;
    public int sellingCost;
    public Item.Rarity rarity;
    public Sprite sprite;
    public bool isAllocated;


    #region Custom Props

    public int forgeLevel;

    // [-50...+50]
    public float firstMarketPrice;
    public float secondMarketPrice;
    public float thirdMarketPrice;

    #endregion


    //public GameItem(Item item)
    //{
    //    uid = ItemMD5Generator.MD5Hash(DateTime.Now.Ticks.ToString());
    //    id = item.id;
    //    nameNative = item.GetNameNative();
    //    rarityNative = item.GetRarityNative();
    //    forges = 0;
    //    defaultCost = item.defaultCost;
    //    sellingCost = item.sellingCost;
    //    rarity = GetRarityRamdonly();
    //    sprite = item.sprite;

    //    forgeLevel = 0;
    //    firstMarketPrice = UnityEngine.Random.Range(-50f, 50f);
    //    secondMarketPrice = UnityEngine.Random.Range(-50f, 50f);
    //    thirdMarketPrice = UnityEngine.Random.Range(-50f, 50f);
    //}

    public GameItem(){
        isAllocated = false;
        timeStamp = long.MaxValue;
    }

    public void ClearInstance(){
        isAllocated = false;
        uid = "";
        timeStamp = long.MaxValue;
        id = "";
        nameNative = "";
        rarityNative = "";
        defaultCost = 0;
        sellingCost = 0;
        rarity = Item.Rarity.COMMON;
        sprite = null;

        forgeLevel = 0;
        firstMarketPrice = 0f;
        secondMarketPrice = 0f;
        thirdMarketPrice = 0f;
    }

    public void OverwriteInstance(Item item){
        
        isAllocated = true;
        uid = ItemMD5Generator.MD5Hash(DateTime.Now.Ticks.ToString());
        timeStamp = DateTime.Now.Ticks;
        id = item.id;
        nameNative = item.GetNameNative();
        rarityNative = item.GetRarityNative();
        defaultCost = item.defaultCost;
        sellingCost = item.sellingCost;
        rarity = item.rarity;
        sprite = item.sprite;

		forgeLevel = item.forgeLevel;
        firstMarketPrice = UnityEngine.Random.Range(-50f, 50f);
        secondMarketPrice = UnityEngine.Random.Range(-50f, 50f);
        thirdMarketPrice = UnityEngine.Random.Range(-50f, 50f);
    }


    #region Getter

    //private Item.Rarity GetRarityRamdonly()
    //{
    //    var r = UnityEngine.Random.Range(0, 100);
    //    if (r <= Farm.COMMON_CHANCE)
    //    {
    //        return Item.Rarity.COMMON;
    //    }
    //    else if (r <= Farm.RARE_CHANCE)
    //    {
    //        return Item.Rarity.RARE;
    //    }
    //    else if (r <= Farm.LEGENDARY_CHANCE)
    //    {
    //        return Item.Rarity.LEGENDARY;
    //    }
    //    else
    //    {
    //        return Item.Rarity.ANCIENT;
    //    }
    //}

    public string GetNameByForgeLevel()
    {
        var stb = new StringBuilder(nameNative);
        stb.Append(" (+");
        stb.Append(forgeLevel);
        stb.Append(")");
        return stb.ToString();
    }

    public int GetCurrentPriceByForgeLevel()
    {
        return ForgeCalculator.GetCurrentPrice(forgeLevel, sellingCost);
    }

    public int GetNextPriceByForgeLevel()
    {
        return ForgeCalculator.GetNextPrice(forgeLevel, sellingCost);
    }

    public int GetForgeCostByForgeLevel()
    {
        return ForgeCalculator.GetCost(forgeLevel, GetCurrentPriceByForgeLevel());
    }

    public int GetForgeProbabilityByForgeLevel()
    {
        return ForgeCalculator.GetProbability(forgeLevel);
    }


    #endregion

}

