using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUIListener : MonoBehaviour {
    private Image thisImage;
    public Image i_SpriteItem, i_SpriteOuter, i_SpriteInner;
    public Sprite sp_CommonOuter, sp_CommonInner;
    public Sprite sp_RareOuter, sp_RareInner;
    public Sprite sp_LegendaryOuter, sp_LegendaryInner;
    public Sprite sp_AncientOuter, sp_AncientInner;
    public Image i_Coin;
    public Text t_ItemName, t_Rarity, t_SellingCost;

    public Button b_Forge, b_Drop;

    [SerializeField ]private Item thisItem;

    private void Awake()
    {
        thisImage = GetComponent<Image>();
        b_Forge.onClick.AddListener(Forge);
        b_Drop.onClick.AddListener(Drop);
    }

    public void OnNotify(Item item){
        thisItem = item;

        thisImage.enabled = true;
        i_Coin.gameObject.SetActive(true);
        i_SpriteItem.gameObject.SetActive(true);
        i_SpriteOuter.gameObject.SetActive(true);
        i_SpriteInner.gameObject.SetActive(true);
        t_ItemName.gameObject.SetActive(true);
        t_Rarity.gameObject.SetActive(true);
        t_SellingCost.gameObject.SetActive(true);
		b_Forge.gameObject.SetActive(true);
        b_Drop.gameObject.SetActive(true);

        if (item.rarity == Item.Rarity.COMMON)
        {
            t_ItemName.color = ItemColorDefine.COMMON_TEXT_COLOR;
            t_Rarity.color = ItemColorDefine.COMMON_TEXT_COLOR;
            i_SpriteOuter.sprite = sp_CommonOuter;
            i_SpriteInner.sprite = sp_CommonInner;
        }
        else if (item.rarity == Item.Rarity.RARE)
        {
            t_ItemName.color = ItemColorDefine.RARE_TEXT_COLOR;
            t_Rarity.color = ItemColorDefine.RARE_TEXT_COLOR;
            i_SpriteOuter.sprite = sp_RareOuter;
            i_SpriteInner.sprite = sp_RareInner;
        }
        else if (item.rarity == Item.Rarity.LEGENDARY)
        {
            t_ItemName.color = ItemColorDefine.LGD_TEXT_COLOR;
            t_Rarity.color = ItemColorDefine.LGD_TEXT_COLOR;
            i_SpriteOuter.sprite = sp_LegendaryOuter;
            i_SpriteInner.sprite = sp_LegendaryInner;
        }
        else
        {
            t_ItemName.color = ItemColorDefine.ANCIENT_TEXT_COLOR;
            t_Rarity.color = ItemColorDefine.ANCIENT_TEXT_COLOR;
            i_SpriteOuter.sprite = sp_AncientOuter;
            i_SpriteInner.sprite = sp_AncientInner;
        }

        t_ItemName.text = item.GetNameNative();
        t_Rarity.text = item.GetRarityNative();
        t_SellingCost.text = item.GetSellingCost().ToString();
        i_SpriteItem.sprite = item.sprite;
    }

    private void Forge(){
        Debug.LogFormat("Forging {0}", thisItem.name);
    }

    private void Drop(){
        
    }
}
