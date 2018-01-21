﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEditor;

public class ItemGenerator :MonoBehaviour
{
    public Texture2D item1, item2, item3, item4, item5;

    private void Awake()
    {
        Sprite[] itemSprites1 = Resources.LoadAll<Sprite>("Image/Item/" + item1.name);
        Sprite[] itemSprites2 = Resources.LoadAll<Sprite>("Image/Item/" + item2.name);
        Sprite[] itemSprites3 = Resources.LoadAll<Sprite>("Image/Item/" + item3.name);
        Sprite[] itemSprites4 = Resources.LoadAll<Sprite>("Image/Item/" + item4.name);
        Sprite[] itemSprites5 = Resources.LoadAll<Sprite>("Image/Item/" + item5.name);
        for (int i = 0; i < itemSprites1.Length; i++){
            
            Item item1 = ScriptableObject.CreateInstance<Item>();
            Item item2 = ScriptableObject.CreateInstance<Item>();
            Item item3 = ScriptableObject.CreateInstance<Item>();
            Item item4 = ScriptableObject.CreateInstance<Item>();

            // Common cost set
            var cost = Random.Range(16, 301);

            item1.defaultCost = cost;
            item1.SetCommon();
            item1.sprite = itemSprites1[i];
            AssetDatabase.CreateAsset(item1, "Assets/Resources/Item/AutoGenerated/Common/item" + i + ".asset");

            item2.defaultCost = cost;
            item2.SetRare();
            item2.sprite = itemSprites1[i];
            AssetDatabase.CreateAsset(item2, "Assets/Resources/Item/AutoGenerated/Rare/item" + i + ".asset");

            item3.defaultCost = cost;
            item3.SetLegendray();
            item3.sprite = itemSprites1[i];
            AssetDatabase.CreateAsset(item3, "Assets/Resources/Item/AutoGenerated/Legendary/item" + i + ".asset");

            item4.defaultCost = cost;
            item4.SetAncient();
            item4.sprite = itemSprites1[i];
            AssetDatabase.CreateAsset(item4, "Assets/Resources/Item/AutoGenerated/Ancient/item" + i + ".asset");
        }

    }
}
