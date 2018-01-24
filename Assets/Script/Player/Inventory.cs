using System.Collections;
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

    public void AddItem(Item item){
        if(IsFull()){
            Debug.Log("No bag size left");
            return;
        }
        inventory.Add(new GameItem(item.id, item.GetNameNative(), item.GetRarityNative(), item.defaultCost, item.sellingCost, item.rarity, item.sprite));
        InventoryUIListener.instance.NotifyToSlots();
        Debug.Log(item.rarity);
    }

    public void SellAllItems(){
        var revenue = 0;
        foreach(var item in inventory){
            revenue += item.sellingCost;
        }
        inventory.Clear();
        Debug.Log(revenue * PlayerManager.instance.GetStatsTrade());
    }

    public void DeleteItem(){
         
    }

    public bool IsFull(){
        if(inventory.Count >= PlayerManager.instance.GetStatsBagSize()){
            return true;
        }
        else {
            return false;
        }
    }

    public GameItem GetLastItem(){
        return inventory[inventory.Count - 1];
    }

}

[System.Serializable]
public class GameItem {
    public string inventoryId;
    public string id;
    public string nameNative;
    public string rarityNative;
    public int forges;
    public int defaultCost;
    public int sellingCost;
    public Item.Rarity rarity;

    public Sprite sprite;

    public GameItem(string _id, string _nameNative, string _rarityNative, int _defaultCost, int _sellingCost, Item.Rarity _rarity, Sprite _sprite){
        inventoryId = ItemMD5Generator.MD5Hash(_id);
        nameNative = _nameNative;
        rarityNative = _rarityNative;
        forges = 0;
        defaultCost = _defaultCost;
        sellingCost = _sellingCost;
        rarity = _rarity;
        sprite = _sprite;
    }
}