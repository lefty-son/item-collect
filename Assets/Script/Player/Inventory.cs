using System;
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

    public void AddItem(List<Item> items){
        if(IsFullWithLeftOver(items.Count)){
            // Partially add items
            ItemShuffle.Shuffle(items);
            var leftOver = PlayerManager.instance.GetStatsBagSize() - inventory.Count;
            Debug.LogFormat("Add {0} items", leftOver);
            for (int i = 0; i < leftOver; i++){
                inventory.Add(new GameItem(items[i]));
            }

        }
        else {
            foreach (var item in items)
            {
                inventory.Add(new GameItem(item));
            }
        }



        // Update UI
        InventoryUIListener.instance.NotifyToSlots();
    }

    public void SellAllItems(){
        var revenue = 0;
        foreach(var item in inventory){
            revenue += item.sellingCost;
        }
        inventory.Clear();
        Debug.Log(revenue * PlayerManager.instance.GetStatsTrade());
    }

    public void DeleteItem(string _uid){
        foreach(var item in inventory.ToArray()){
            if(item.uid.Equals(_uid)){
                inventory.Remove(item);
            }
        }

        // Update UI
        InventoryUIListener.instance.NotifyToSlots();
    }

    public bool IsFull(){
        if(inventory.Count> PlayerManager.instance.GetStatsBagSize()){
            return true;
        }
        else {
            return false;
        }
    }

    public bool IsFullWithLeftOver(int count){
        if (inventory.Count + count > PlayerManager.instance.GetStatsBagSize())
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

    public GameItem(string _id, string _nameNative, string _rarityNative, int _defaultCost, int _sellingCost, Item.Rarity _rarity, Sprite _sprite){
        uid = ItemMD5Generator.MD5Hash(DateTime.Now.Ticks.ToString());
        id = _id;
        nameNative = _nameNative;
        rarityNative = _rarityNative;
        forges = 0;
        defaultCost = _defaultCost;
        sellingCost = _sellingCost;
        rarity = _rarity;
        sprite = _sprite;
    }

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
    }
}

