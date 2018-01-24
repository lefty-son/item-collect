﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Farm : MonoBehaviour
{

    public static Farm instance;

    public Slider farmSlider;
    [SerializeField]
    private bool farmable;

    public Item tempItem;

    private readonly int COMMON_CHANCE = 68;
    private readonly int RARE_CHANCE = 87;
    private readonly int LEGENDARY_CHANCE = 97;

    private Item[] itemsCommon1, itemsRare1, itemsLegendary1, itemsAncient1;
    private Item[] itemsCommon2, itemsRare2, itemsLegendary2, itemsAncient2;
    private Item[] itemsCommon3, itemsRare3, itemsLegendary3, itemsAncient3;
    private Item[] itemsCommon4, itemsRare4, itemsLegendary4, itemsAncient4;
    private Item[] itemsCommon5, itemsRare5, itemsLegendary5, itemsAncient5;

    private void Awake()
    {
        if (instance == null) instance = this;
        GetItemResources();
    }

    private void GetItemResources()
    {
        itemsCommon1 = Resources.LoadAll<Item>("Item/AutoGenerated/Common/01");
        itemsCommon2 = Resources.LoadAll<Item>("Item/AutoGenerated/Common/02");
        itemsCommon3 = Resources.LoadAll<Item>("Item/AutoGenerated/Common/03");
        itemsCommon4 = Resources.LoadAll<Item>("Item/AutoGenerated/Common/04");
        itemsCommon5 = Resources.LoadAll<Item>("Item/AutoGenerated/Common/05");

        itemsRare1 = Resources.LoadAll<Item>("Item/AutoGenerated/Rare/01");
        itemsRare2 = Resources.LoadAll<Item>("Item/AutoGenerated/Rare/02");
        itemsRare3 = Resources.LoadAll<Item>("Item/AutoGenerated/Rare/03");
        itemsRare4 = Resources.LoadAll<Item>("Item/AutoGenerated/Rare/04");
        itemsRare5 = Resources.LoadAll<Item>("Item/AutoGenerated/Rare/05");

        itemsLegendary1 = Resources.LoadAll<Item>("Item/AutoGenerated/Legendary/01");
        itemsLegendary2 = Resources.LoadAll<Item>("Item/AutoGenerated/Legendary/02");
        itemsLegendary3 = Resources.LoadAll<Item>("Item/AutoGenerated/Legendary/03");
        itemsLegendary4 = Resources.LoadAll<Item>("Item/AutoGenerated/Legendary/04");
        itemsLegendary5 = Resources.LoadAll<Item>("Item/AutoGenerated/Legendary/05");

        itemsAncient1 = Resources.LoadAll<Item>("Item/AutoGenerated/Ancient/01");
        itemsAncient2 = Resources.LoadAll<Item>("Item/AutoGenerated/Ancient/02");
        itemsAncient3 = Resources.LoadAll<Item>("Item/AutoGenerated/Ancient/03");
        itemsAncient4 = Resources.LoadAll<Item>("Item/AutoGenerated/Ancient/04");
        itemsAncient5 = Resources.LoadAll<Item>("Item/AutoGenerated/Ancient/05");
    }

    public void Init(){
        ResetSlider();
        farmable = true;
    }

    public Item GetTempItem(){
        return tempItem;
    }

    private void Update()
    {
        if(GameManager.instance.IsPlaying && farmable && !Inventory.instance.IsFull()){
            farmSlider.value += Time.deltaTime;
        }
        if(farmSlider.value >= farmSlider.maxValue && !Inventory.instance.IsFull()){
            ResetSlider();
            Roll();
            UIManager.instance.OnDiscover();
            UIManager.instance.OffFarm();
        }
    }

    private void ResetSlider(){
        farmSlider.value = 0;
        farmable = false;
    }

    #region ROLL AND PICK

    public void Roll()
    {
        var r = Random.Range(0, 100);
        if (r <= COMMON_CHANCE)
        {
            tempItem = PickCommon();
        }
        else if (r <= RARE_CHANCE)
        {
            tempItem = PickRare();
        }
        else if (r <= LEGENDARY_CHANCE)
        {
            tempItem = PickLegendary();
        }
        else
        {
            tempItem = PickAncient();
        }
    }

    public Item PickCommon()
    {
        var r = Random.Range(0, 5);
        if (r == 0)
        {
            return itemsCommon1[Random.Range(0, itemsCommon1.Length)];
        }
        else if (r == 1)
        {
            return itemsCommon2[Random.Range(0, itemsCommon2.Length)];
        }
        else if (r == 2)
        {
            return itemsCommon3[Random.Range(0, itemsCommon3.Length)];
        }
        else if (r == 3)
        {
            return itemsCommon4[Random.Range(0, itemsCommon4.Length)];
        }
        else if (r == 4)
        {
            return itemsCommon5[Random.Range(0, itemsCommon5.Length)];
        }
        else
        {
            return itemsCommon1[Random.Range(0, itemsCommon1.Length)];
        }
    }

    public Item PickRare()
    {
        var r = Random.Range(0, 5);
        if (r == 0)
        {
            return itemsRare1[Random.Range(0, itemsRare1.Length)];
        }
        else if (r == 1)
        {
            return itemsRare2[Random.Range(0, itemsRare2.Length)];
        }
        else if (r == 2)
        {
            return itemsRare3[Random.Range(0, itemsRare3.Length)];
        }
        else if (r == 3)
        {
            return itemsRare4[Random.Range(0, itemsRare4.Length)];
        }
        else if (r == 4)
        {
            return itemsRare5[Random.Range(0, itemsRare5.Length)];
        }
        else
        {
            return itemsRare1[Random.Range(0, itemsRare1.Length)];
        }
    }

    public Item PickLegendary()
    {
        var r = Random.Range(0, 5);
        if (r == 0)
        {
            return itemsLegendary1[Random.Range(0, itemsLegendary1.Length)];
        }
        else if (r == 1)
        {
            return itemsLegendary2[Random.Range(0, itemsLegendary2.Length)];
        }
        else if (r == 2)
        {
            return itemsLegendary3[Random.Range(0, itemsLegendary3.Length)];
        }
        else if (r == 3)
        {
            return itemsLegendary4[Random.Range(0, itemsLegendary4.Length)];
        }
        else if (r == 4)
        {
            return itemsLegendary5[Random.Range(0, itemsLegendary5.Length)];
        }
        else
        {
            return itemsLegendary1[Random.Range(0, itemsLegendary1.Length)];
        }
    }

    public Item PickAncient()
    {
        var r = Random.Range(0, 5);
        if (r == 0)
        {
            return itemsAncient1[Random.Range(0, itemsAncient1.Length)];
        }
        else if (r == 1)
        {
            return itemsAncient2[Random.Range(0, itemsAncient2.Length)];
        }
        else if (r == 2)
        {
            return itemsAncient3[Random.Range(0, itemsAncient3.Length)];
        }
        else if (r == 3)
        {
            return itemsAncient4[Random.Range(0, itemsAncient4.Length)];
        }
        else if (r == 4)
        {
            return itemsAncient5[Random.Range(0, itemsAncient5.Length)];
        }
        else
        {
            return itemsAncient1[Random.Range(0, itemsAncient1.Length)];
        }
    }

    #endregion

}
