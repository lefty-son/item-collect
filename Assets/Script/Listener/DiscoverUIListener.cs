using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscoverUIListener : MonoBehaviour {
    public Text t_ItemName;
    public Image i_SpriteItem, i_SpriteOuter, i_SpriteInner;
    public Image i_BGGradient, i_CircleGradient;
    public Sprite sp_CommonOuter, sp_CommonInner;
    public Sprite sp_RareOuter, sp_RareInner;
    public Sprite sp_LegendaryOuter, sp_LegendaryInner;
    public Sprite sp_AncientOuter, sp_AncientInner;

    private void OnEnable()
    {
        var item = Farm.instance.GetTempItem();

        /* Set as rarity */
        if(item.rarity == Item.Rarity.COMMON){
            i_BGGradient.color = ItemColorDefine.COMMON_BG_GRADIENT_COLOR;
            i_CircleGradient.color = ItemColorDefine.COMMON_CIRCLE_GRADIENT_COLOR;
            t_ItemName.color = ItemColorDefine.COMMON_TEXT_COLOR;
            i_SpriteOuter.sprite = sp_CommonOuter;
            i_SpriteInner.sprite = sp_CommonInner;
        }
        else if(item.rarity == Item.Rarity.RARE){
            i_BGGradient.color = ItemColorDefine.RARE_BG_GRADIENT_COLOR;
            i_CircleGradient.color = ItemColorDefine.RARE_CIRCLE_GRADIENT_COLOR;
            t_ItemName.color = ItemColorDefine.RARE_TEXT_COLOR;
            i_SpriteOuter.sprite = sp_RareOuter;
            i_SpriteInner.sprite = sp_RareInner;
        }
        else if (item.rarity == Item.Rarity.LEGENDARY)
        {
            i_BGGradient.color = ItemColorDefine.LGD_BG_GRADIENT_COLOR;
            i_CircleGradient.color = ItemColorDefine.LGD_CIRCLE_GRADIENT_COLOR;
            t_ItemName.color = ItemColorDefine.LGD_TEXT_COLOR;
            i_SpriteOuter.sprite = sp_LegendaryOuter;
            i_SpriteInner.sprite = sp_LegendaryInner;
        }
        else {
            i_BGGradient.color = ItemColorDefine.ANCIENT_BG_GRADIENT_COLOR;
            i_CircleGradient.color = ItemColorDefine.ANCIENT_CIRCLE_GRADIENT_COLOR;
            t_ItemName.color = ItemColorDefine.ANCIENT_TEXT_COLOR;
            i_SpriteOuter.sprite = sp_AncientOuter;
            i_SpriteInner.sprite = sp_AncientInner;
        }
        /* ------------- */

        t_ItemName.text = item.GetNameNative();
        i_SpriteItem.sprite = item.sprite;
    }
}
