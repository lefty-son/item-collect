using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject {
    public string id;
    public string EN_Name;
	public string KR_Name;
    public string JP_Name;
    public string Simple_CN_Name;
    public string Traditional_CN_Name;
    public int cost;
    //[0~67 / 68~87 / 88 ~ 96 / 97 ~ 99]
    public enum Rarity {
        COMMON, RARE, LEGENDARY, ANCIENT
    }
    public Rarity rarity;
    public Sprite sprite;
}
