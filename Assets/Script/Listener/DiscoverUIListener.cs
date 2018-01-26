using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscoverUIListener : MonoBehaviour {
    public GameObject[] tempSlots;
    public Button[] chests;
    public Image[] i_Coin;
    public Text[] t_Cost;
    public Text[] t_ItemName;
    public Image[] i_SpriteItem, i_SpriteOuter, i_SpriteInner;
    public Image i_BGGradient;
    public Sprite sp_CommonOuter, sp_CommonInner;
    public Sprite sp_RareOuter, sp_RareInner;
    public Sprite sp_LegendaryOuter, sp_LegendaryInner;
    public Sprite sp_AncientOuter, sp_AncientInner;

    public Animation[] a_TempSlotShrink;

    [SerializeField]
    private Item.Rarity highestRarity;

    private int chestCount;
    private int openChestCount;

    public void OpenChest(int i){
        chests[i].interactable = false;
        chests[i].gameObject.SetActive(false);
        t_ItemName[i].gameObject.SetActive(true);
        i_SpriteItem[i].gameObject.SetActive(true);
        i_SpriteOuter[i].gameObject.SetActive(true);
        i_SpriteInner[i].gameObject.SetActive(true);
        t_Cost[i].gameObject.SetActive(true);
        i_Coin[i].gameObject.SetActive(true);

        openChestCount++;
        if(openChestCount >= chestCount){
            StartCoroutine(ShrinkAnim());
        }
    }

    private IEnumerator ShrinkAnim(){
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < chestCount; i++){
            a_TempSlotShrink[i].Play();
			yield return new WaitForSeconds(0.2f);
        }
        UIManager.instance.OnClickArchive();
    }



    private void OnEnable()
    {
        var items = Farm.instance.GetTempItem(true);

        chestCount = items.Count;
        openChestCount = 0;

        for (int i = 0; i < items.Count; i++){
            t_ItemName[i].gameObject.SetActive(false);
            i_SpriteItem[i].gameObject.SetActive(false);
            i_SpriteOuter[i].gameObject.SetActive(false);
            i_SpriteInner[i].gameObject.SetActive(false);
            t_Cost[i].gameObject.SetActive(false);
            i_Coin[i].gameObject.SetActive(false);


            tempSlots[i].SetActive(true);
            tempSlots[i].transform.localScale = Vector3.one * 1;
            chests[i].interactable = true;
            chests[i].gameObject.SetActive(true);

            // Set highest rarity
            SetHighestRarity(items[i].rarity);

            /* Set as rarity */
            if (items[i].rarity == Item.Rarity.COMMON)
            {
                t_ItemName[i].color = ItemColorDefine.COMMON_TEXT_COLOR;
                i_SpriteOuter[i].sprite = sp_CommonOuter;
                i_SpriteInner[i].sprite = sp_CommonInner;
            }
            else if (items[i].rarity == Item.Rarity.RARE)
            {
                t_ItemName[i].color = ItemColorDefine.RARE_TEXT_COLOR;
                i_SpriteOuter[i].sprite = sp_RareOuter;
                i_SpriteInner[i].sprite = sp_RareInner;
            }
            else if (items[i].rarity == Item.Rarity.LEGENDARY)
            {
                t_ItemName[i].color = ItemColorDefine.LGD_TEXT_COLOR;
                i_SpriteOuter[i].sprite = sp_LegendaryOuter;
                i_SpriteInner[i].sprite = sp_LegendaryInner;
            }
            else
            {
                t_ItemName[i].color = ItemColorDefine.ANCIENT_TEXT_COLOR;
                i_SpriteOuter[i].sprite = sp_AncientOuter;
                i_SpriteInner[i].sprite = sp_AncientInner;
            }

            // Set BGGradient color as highest rarity
            if(highestRarity == Item.Rarity.COMMON){
                i_BGGradient.color = ItemColorDefine.COMMON_BG_GRADIENT_COLOR;
            }
            else if(highestRarity == Item.Rarity.RARE){
                i_BGGradient.color = ItemColorDefine.RARE_BG_GRADIENT_COLOR;

            }
            else if (highestRarity == Item.Rarity.LEGENDARY)
            {
                i_BGGradient.color = ItemColorDefine.LGD_BG_GRADIENT_COLOR;

            }
            else {
                i_BGGradient.color = ItemColorDefine.ANCIENT_BG_GRADIENT_COLOR;

            }
            /* ------------- */

            t_ItemName[i].text = items[i].GetNameByForgeLevel();
            t_Cost[i].text = items[i].GetCurrentPriceByForgeLevel().ToString();
            i_SpriteItem[i].sprite = items[i].sprite;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < 4; i++){
            t_ItemName[i].gameObject.SetActive(false);
            i_SpriteItem[i].gameObject.SetActive(false);
            i_SpriteOuter[i].gameObject.SetActive(false);
            i_SpriteInner[i].gameObject.SetActive(false);
            t_Cost[i].gameObject.SetActive(false);
            i_Coin[i].gameObject.SetActive(false);


            tempSlots[i].transform.localScale = Vector3.one;
            tempSlots[i].SetActive(false);
            //chests[i].interactable = true;
            //chests[i].gameObject.SetActive(true);
        }
        highestRarity = Item.Rarity.COMMON;
    }

    private void SetHighestRarity(Item.Rarity _rarity){
        if(_rarity >= highestRarity){
            highestRarity = _rarity;
        }
    }
}
