using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TravelManager : MonoBehaviour {
    public static TravelManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void MoveToA()
    {
        PlayerManager.instance.SetCurrentLocation(0);
        var totalFee = (int)(Inventory.instance.GetTariff() * (1.00f - PlayerManager.instance.GetStatsTradeValue()));
        CurrencyManager.instance.MinusGoldByValue(totalFee);
        UIManager.instance.StartFadeToTravel();
    }

    public void MoveToB()
    {
        PlayerManager.instance.SetCurrentLocation(1);
        var totalFee = (int)(Inventory.instance.GetTariff() * (1.00f - PlayerManager.instance.GetStatsTradeValue()));
        CurrencyManager.instance.MinusGoldByValue(totalFee);
        UIManager.instance.StartFadeToTravel();
    }

    public void MoveToC()
    {
        PlayerManager.instance.SetCurrentLocation(2);
        var totalFee = (int)(Inventory.instance.GetTariff() * (1.00f - PlayerManager.instance.GetStatsTradeValue()));
        CurrencyManager.instance.MinusGoldByValue(totalFee);
        UIManager.instance.StartFadeToTravel();
    }
}
