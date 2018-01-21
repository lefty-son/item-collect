﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour {

    public static Inventory instance;

    public List<Item> inventory;

    private void Awake()
    {
        if (instance == null) instance = this;
        inventory = new List<Item>();
    }

    public void AddItem(Item item){
        if(inventory.Count >= PlayerManager.instance.GetStatsBagSize()){
            Debug.Log("No bag size left");
            return;
        }
        inventory.Add(item);
        Debug.Log(item.rarity);
    }

}







