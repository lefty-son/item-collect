using System.Collections;
using System.Collections.Generic;
using System.Text;
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
    public Text t_ItemName, t_Rarity, t_Damaged, t_Maintain;
    public Text t_AMarketPrice, t_BMarketPrice, t_CMarketPrice;
    public Text t_ATown, t_BTown, t_CTown;

    public Button b_Forge, b_Drop, b_Sell;

    [SerializeField ]private GameItem thisItem;

    private void Awake()
    {
        thisImage = GetComponent<Image>();
        b_Forge.onClick.AddListener(Forge);
        b_Drop.onClick.AddListener(Drop);
        b_Sell.onClick.AddListener(Sell);
    }

    public void ActiveAllHolders(){
        thisImage.enabled = true;
        i_Coin.gameObject.SetActive(true);
        i_SpriteItem.gameObject.SetActive(true);
        i_SpriteOuter.gameObject.SetActive(true);
        i_SpriteInner.gameObject.SetActive(true);
        t_ItemName.gameObject.SetActive(true);
        t_Rarity.gameObject.SetActive(true);
        b_Forge.gameObject.SetActive(true);
        b_Drop.gameObject.SetActive(true);
        b_Sell.gameObject.SetActive(true);
        t_AMarketPrice.gameObject.SetActive(true);
        t_BMarketPrice.gameObject.SetActive(true);
        t_CMarketPrice.gameObject.SetActive(true);

        t_Damaged.gameObject.SetActive(true);
        t_Maintain.gameObject.SetActive(true);
        t_ATown.gameObject.SetActive(true);
        t_BTown.gameObject.SetActive(true);
        t_CTown.gameObject.SetActive(true);
    }

    public void InactiveAllHolders(){
        thisItem = null;
        thisImage.enabled = false;
        i_Coin.gameObject.SetActive(false);
        i_SpriteItem.gameObject.SetActive(false);
        i_SpriteOuter.gameObject.SetActive(false);
        i_SpriteInner.gameObject.SetActive(false);
        t_ItemName.gameObject.SetActive(false);
        t_Rarity.gameObject.SetActive(false);
        b_Forge.gameObject.SetActive(false);
        b_Drop.gameObject.SetActive(false);
        b_Sell.gameObject.SetActive(false);
        t_AMarketPrice.gameObject.SetActive(false);
        t_BMarketPrice.gameObject.SetActive(false);
        t_CMarketPrice.gameObject.SetActive(false);

        t_Damaged.gameObject.SetActive(false);
        t_Maintain.gameObject.SetActive(false);
        t_ATown.gameObject.SetActive(false);
        t_BTown.gameObject.SetActive(false);
        t_CTown.gameObject.SetActive(false);
    }


    public void OnNotify(GameItem item){
        
        thisItem = item;
        if(thisItem.isAllocated){
            gameObject.SetActive(true);
            ActiveAllHolders();

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

            t_ItemName.text = item.GetNameByForgeLevel();
            t_Rarity.text = item.rarityNative;
            //t_SellingCost.text = item.GetCurrentPriceByForgeLevel().ToString();
            i_SpriteItem.sprite = item.sprite;

            // Raw price only
            t_AMarketPrice.text = item.GetFirstMarketPriceValue().ToString();
            t_BMarketPrice.text = item.GetSecondMarketPriceValue().ToString();
            t_CMarketPrice.text = item.GetThirdMarketPriceValue().ToString();

            var maintainStb = new StringBuilder(Localizer.instance.GetTextFromLocal("t_Maintain_key"));
            maintainStb.Append(": ");
            maintainStb.Append(item.GetMaintainValue());
            t_Maintain.text = maintainStb.ToString();

            //t_AMarketPrice.text = GetFormattedMarketPrice(item.GetFirstMarketPriceValue());
            //t_BMarketPrice.text = GetFormattedMarketPrice(item.GetSecondMarketPriceValue());
            //t_CMarketPrice.text = GetFormattedMarketPrice(item.GetThirdMarketPriceValue());
            //t_AMarketPrice.color = GetMarketPriceColor(item.firstMarketPrice);
            //t_BMarketPrice.color = GetMarketPriceColor(item.secondMarketPrice);
            //t_CMarketPrice.color = GetMarketPriceColor(item.thirdMarketPrice);
            Debug.Log(Inventory.instance.GetMaintain());
        }
        else {
            
            InactiveAllHolders();
            gameObject.SetActive(false);
        }


    }

    private void Forge(){
        if(thisItem.forgeLevel >= GameManager.instance.MAX_FORGE_LEVEL){
            Debug.Log("Cannot forge moar!");
            return;
        }
        UIManager.instance.OnForge();
        ForgeUIListener.instance.GetForgeItemFromSlot(thisItem, i_SpriteOuter.sprite, i_SpriteInner.sprite, t_ItemName.color);
    }

    private void Drop(){
        Inventory.instance.DeleteItem(thisItem);
    }

    private void Sell(){
        Debug.LogFormat("selling  {0} {1} {2}", thisItem.GetNameByForgeLevel(), thisItem.GetSecondMarketPriceValue(), thisItem.GetCurrentPriceByForgeLevel() );
    }
     

    public string GetFormattedMarketPrice(float prob){
        string mark;
        if(prob >= 0){
            mark = "▲";
        }
        else {
            mark = "▼";
        }
        var formattedString = new StringBuilder(mark);
        formattedString.Append(prob.ToString("F1"));
        formattedString.Append("%");
        return formattedString.ToString();
    }

    private Color GetMarketPriceColor(float prob){
        if(prob >= 0){
            return Color.blue;
        }
        else {
            return Color.red;
        }
    }
}
