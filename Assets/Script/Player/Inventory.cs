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
    }

    public void AddItem(List<GameItem> items){
        if(IsFullWithLeftOver(items.Count)){
            // Partially add items
            ItemShuffle.Shuffle(items);
            var leftOver = PlayerManager.instance.GetStatsBagSizeValue() - inventory.Count;
            Debug.LogFormat("Add {0} items", leftOver);
            for (int i = 0; i < leftOver; i++){
                inventory.Add(items[i]);
            }
        }
        else {
            foreach (var item in items)
            {
                inventory.Add(item);
            }
        }



        // Update UI
        //InventoryUIListener.instance.NotifyToSlots();
    }

    public void SellAllItems(){
        var revenue = 0;
        foreach(var item in inventory){
            revenue += item.sellingCost;
        }
        inventory.Clear();
    }

    public void DeleteItem(GameItem item){
		inventory.Remove(item);
        InventoryUIListener.instance.NotifyToSlots();
    }

    public bool IsFull(){
        if(inventory.Count> PlayerManager.instance.GetStatsBagSizeValue()){
            return true;
        }
        else {
            return false;
        }
    }

    public bool IsFullWithLeftOver(int count){
        if (inventory.Count + count > PlayerManager.instance.GetStatsBagSizeValue())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public GameItem GetLastItem(){
        return inventory[inventory.Count - 1];
    }



}

[System.Serializable]
public class GameItem {
    public string uid;
    public string id;
    public string nameNative;
    public string rarityNative;
    public int forges;
    public int defaultCost;
    public int sellingCost;
    public Item.Rarity rarity;
    public Sprite sprite;


    #region Custom Props

    public int forgeLevel;

    // [-50...+50]
    public float firstMarketPrice;
    public float secondMarketPrice;
    public float thirdMarketPrice;

    #endregion


    public GameItem(Item item){
        uid = ItemMD5Generator.MD5Hash(DateTime.Now.Ticks.ToString());
        id = item.id;
        nameNative = item.GetNameNative();
        rarityNative = item.GetRarityNative();
        forges = 0;
        defaultCost = item.defaultCost;
        sellingCost = item.sellingCost;
        rarity = item.rarity;
        sprite = item.sprite;
        forgeLevel = 0;
        firstMarketPrice = UnityEngine.Random.Range(-50f, 50f);
        secondMarketPrice = UnityEngine.Random.Range(-50f, 50f);
        thirdMarketPrice = UnityEngine.Random.Range(-50f, 50f);
    }

    public string GetNameByForgeLevel(){
        var stb = new StringBuilder(nameNative);
        stb.Append(" (+");
        stb.Append(forgeLevel);
        stb.Append(")");
        return stb.ToString();
    }


    public int GetCurrentPriceByForgeLevel(){
        return ForgeCalculator.GetCurrentPrice(forgeLevel, sellingCost);
    }

    public int GetNextPriceByForgeLevel(){
        return ForgeCalculator.GetNextPrice(forgeLevel, sellingCost);
    }

    public int GetForgeCostByForgeLevel(){
        return ForgeCalculator.GetCost(forgeLevel, GetCurrentPriceByForgeLevel());
    }

    public int GetForgeProbabilityByForgeLevel(){
        return ForgeCalculator.GetProbability(forgeLevel);
    }

}

