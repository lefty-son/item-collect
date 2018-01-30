using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelUIListener : MonoBehaviour {
    public GameObject aTownCurrentLocationHolder, bTownCurrentLocationHolder, cTownCurrentLocationHolder;
    public Button b_ATown, b_BTown, b_CTown;
    public Text t_FeeValue, t_AffordableWarning;

    private void OnEnable()
    {
        var totalFee = (int)(Inventory.instance.GetTariff() * (1.00f - PlayerManager.instance.GetStatsTradeValue()));
        var isAffordable = CurrencyManager.instance.GetGold() >= totalFee ? true : false;

        t_AffordableWarning.gameObject.SetActive(!isAffordable);

        OffAllCurrentLocationHolder();
        if(PlayerManager.instance.GetCurrentLocation() == 0){
            aTownCurrentLocationHolder.SetActive(true);

            b_ATown.interactable = false;
            b_BTown.interactable = isAffordable;
            b_CTown.interactable = isAffordable;
        }
        else if (PlayerManager.instance.GetCurrentLocation() == 1)
        {
            bTownCurrentLocationHolder.SetActive(true);

            b_BTown.interactable = false;
            b_ATown.interactable = isAffordable;
            b_CTown.interactable = isAffordable;
        }
        else {
            cTownCurrentLocationHolder.SetActive(true);

            b_CTown.interactable = false;
            b_ATown.interactable = isAffordable;
            b_BTown.interactable = isAffordable;
        }
        t_FeeValue.text = totalFee.ToString();

    }

    private void OffAllCurrentLocationHolder(){
        aTownCurrentLocationHolder.SetActive(false);
        bTownCurrentLocationHolder.SetActive(false);
        cTownCurrentLocationHolder.SetActive(false);
    }
}
