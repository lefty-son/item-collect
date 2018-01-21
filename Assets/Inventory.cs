using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Inventory : MonoBehaviour {

    public static Inventory instance;

    public Item[] items;

    [SerializeField]
    private Dictionary<Item, int> inventory;

    private void Awake()
    {
        if (instance == null) instance = this;
        items = Resources.LoadAll<Item>("Item");
        inventory = new Dictionary<Item, int>();
    }



    public void PickOne()
    {
                      
    }
}













