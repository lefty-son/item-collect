using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnResultUIListener : MonoBehaviour {
    public static OnResultUIListener instance;

    public Animation anim;

    public Image i_SpriteItem, i_SpriteOuter, i_SpriteInner, i_Fail;
    public Text t_ItemName, t_Rarity, t_Price, t_IntervalPrice;

    public Sprite sp_CommonOuter, sp_CommonInner;
    public Sprite sp_RareOuter, sp_RareInner;
    public Sprite sp_LegendaryOuter, sp_LegendaryInner;
    public Sprite sp_AncientOuter, sp_AncientInner;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void GetItemInfoOnSuccess(GameItem item){
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

        i_SpriteItem.sprite = item.sprite;
        t_ItemName.text = item.GetNameByForgeLevel();
        t_Rarity.text = item.rarityNative;
        i_Fail.gameObject.SetActive(false);
        t_Price.text = item.GetCurrentPriceByForgeLevel().ToString();

        var intervalPriceStb = new StringBuilder("(+");
        intervalPriceStb.Append((item.GetCurrentPriceByForgeLevel() - item.GetPreviousPriceByForgeLevel()));
        intervalPriceStb.Append(")");
        t_IntervalPrice.text = intervalPriceStb.ToString();
    }

    public void GetItemInfoOnFail(GameItem item){
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

        Debug.Log("Fail");
        i_SpriteItem.sprite = item.sprite;
        t_ItemName.text = item.GetNameByForgeLevel();
        t_Rarity.text = item.rarityNative;
        i_Fail.gameObject.SetActive(true);
        t_Price.text = item.GetCurrentPriceByForgeLevel().ToString();
        t_IntervalPrice.text = "";
    }

    public void OffOnResultPanel(){
        anim.Play();
    }

}
