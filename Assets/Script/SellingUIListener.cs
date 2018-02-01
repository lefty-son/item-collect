using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellingUIListener : MonoBehaviour {

    public static SellingUIListener instance;

    private int marketPrice;
    private int suggestPrice;


    [SerializeField]
    private GameItem thisItem;

    public Image i_SpriteOuter, i_SpriteInner, i_SpriteItem;
	public Text t_ItemName, t_Rarity;
    public Text t_MarketPrice, t_SuggestedPrice;
    public Button b_Sell;
    public Text t_CilentSay;

    private void Awake()
    {
        if (instance == null) instance = this;
        b_Sell.onClick.AddListener(Sell);
    }

    public void GetItemInfoToSell(GameItem item, Sprite outer, Sprite inner){
        thisItem = item;
        i_SpriteOuter.sprite = outer;
        i_SpriteInner.sprite = inner;
        i_SpriteItem.sprite = item.sprite;

        t_ItemName.text = item.GetNameByForgeLevel();
        t_Rarity.text = item.rarityNative;

        if(PlayerManager.instance.GetCurrentLocation() == 0){
            marketPrice = item.GetFirstMarketPriceValue();
            t_MarketPrice.text = item.GetFirstMarketPriceValue().ToString();
        }
        else if (PlayerManager.instance.GetCurrentLocation() == 1)
        {
            marketPrice = item.GetSecondMarketPriceValue();
            t_MarketPrice.text = item.GetSecondMarketPriceValue().ToString();
        }
        else {
            marketPrice = item.GetThirdMarketPriceValue();
            t_MarketPrice.text = item.GetThirdMarketPriceValue().ToString();
        }

    }

    public void Sell(){
        CurrencyManager.instance.PlusGoldByValue(suggestPrice);
        Inventory.instance.DeleteItem(thisItem);
        gameObject.SetActive(false);
    }

    public void Negotiate(){
        suggestPrice = Random.Range(0, marketPrice);
        Debug.Log(marketPrice);
        t_SuggestedPrice.text = suggestPrice.ToString();
    }


}
