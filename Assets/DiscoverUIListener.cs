using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscoverUIListener : MonoBehaviour {
    public Text t_ItemName;
    public Image i_Sprite;

    private void OnEnable()
    {
        var item = Inventory.instance.GetLastItem();
        t_ItemName.text = item.GetNameNative();
        i_Sprite.sprite = item.sprite;
    }
}
