using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Inventory : MonoBehaviour {

    public static Inventory instance;

    public Item[] commonItems, rareItems, legendaryItems, ancientItems;

    [SerializeField]
    private List<Item> myInventory;

    private void Awake()
    {
        if (instance == null) instance = this;
        commonItems = Resources.LoadAll<Item>("Item/Common");
        rareItems = Resources.LoadAll<Item>("Item/Rare");
        legendaryItems = Resources.LoadAll<Item>("Item/Legendary");
        ancientItems = Resources.LoadAll<Item>("Item/Ancient");
        myInventory = new List<Item>();
    }

    public void PickOne()
    {
        var r = Random.Range(0, commonItems.Length);
        Debug.Log(commonItems[r].KR_Name + " picked up");
        Debug.Log(commonItems[r].cost + " picked up");
        myInventory.Add(commonItems[r]);
    }
}
