using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowthUIListener : MonoBehaviour {



    #region Trade
    public Text t_TradeDesc, t_TradeLevel, t_TradeUpgradeCost;
    public Button b_TradeUp;
    #endregion


    #region Persuasion
    public Text t_PersuasionDesc, t_PersuasionLevel, t_PersuasionUpgradeCost;
    public Button b_PersuasionUp;
    #endregion


    #region Luck
    public Text t_LuckDesc, t_LuckLevel, t_LuckUpgradeCost;
    public Button b_LuckUp;
    #endregion

    private void Awake()
    {
        b_TradeUp.onClick.AddListener(delegate {
            CurrencyManager.instance.MinusGoldByValue(GetTradeNextLevelCost());
            PlayerManager.instance.SetStatsTradeLevelUp();
            UpdateUI();
        });
        b_PersuasionUp.onClick.AddListener(delegate {
            CurrencyManager.instance.MinusGoldByValue(GetPersuasionNextLevelCost());
            PlayerManager.instance.SetStatsPersuasionLevelUp();
            UpdateUI();
        });
        b_LuckUp.onClick.AddListener(delegate
        {
            CurrencyManager.instance.MinusGoldByValue(GetLuckNextLevelCost());
            PlayerManager.instance.SetStatsLuckLevelUp();
            UpdateUI();
        });
    }

    private void UpdateUI(){
        b_TradeUp.interactable = CurrencyManager.instance.CheckGoldAffordable(GetTradeNextLevelCost());
        b_PersuasionUp.interactable = CurrencyManager.instance.CheckGoldAffordable(GetPersuasionNextLevelCost());
        b_LuckUp.interactable = CurrencyManager.instance.CheckGoldAffordable(GetLuckNextLevelCost());


        var tradeStb = new StringBuilder(Localizer.instance.GetTextFromLocal("t_Level_key"));
        var persuasionStb = new StringBuilder(Localizer.instance.GetTextFromLocal("t_Level_key"));
        var luckStb = new StringBuilder(Localizer.instance.GetTextFromLocal("t_Level_key"));

        tradeStb.Append(PlayerManager.instance.GetStatsTradeLevel());
        persuasionStb.Append(PlayerManager.instance.GetStatsPersuasionLevel());
        luckStb.Append(PlayerManager.instance.GetStatsLuckLevel());

        t_TradeLevel.text = tradeStb.ToString();
        t_PersuasionLevel.text = persuasionStb.ToString();
        t_LuckLevel.text = luckStb.ToString();

        t_TradeUpgradeCost.text = GetTradeNextLevelCost().ToString();
        t_PersuasionUpgradeCost.text = GetPersuasionNextLevelCost().ToString();
        t_LuckUpgradeCost.text = GetLuckNextLevelCost().ToString();

        var tradeDescStb1 = new StringBuilder(Localizer.instance.GetTextFromLocal("t_TradeDesc1_key"));
        var tradeDescStb2 = new StringBuilder(Localizer.instance.GetTextFromLocal("t_TradeDesc2_key"));
        var persuasionDescStb1 = new StringBuilder(Localizer.instance.GetTextFromLocal("t_PersuasionDesc1_key"));
        var persuasionDescStb2 = new StringBuilder(Localizer.instance.GetTextFromLocal("t_PersuasionDesc2_key"));
        var luckDescStb1 = new StringBuilder(Localizer.instance.GetTextFromLocal("t_LuckDesc1_key"));
        var luckDescStb2 = new StringBuilder(Localizer.instance.GetTextFromLocal("t_LuckDesc2_key"));

        tradeDescStb1.Append((PlayerManager.instance.GetStatsTradeValue() * 100).ToString("F1")).Append("%").Append("\n\n");
        tradeDescStb2.Append((PlayerManager.instance.GetStatsTradeValue() * 100).ToString("F1")).Append("%");
        persuasionDescStb1.Append(PlayerManager.instance.GetStatsPersuasionValue().ToString("F1")).Append("%").Append("\n\n");
        persuasionDescStb2.Append(PlayerManager.instance.GetStatsPersuasionValue().ToString("F1")).Append("%");
        luckDescStb1.Append(PlayerManager.instance.GetStatsLuckValue().ToString("F1")).Append("%").Append("\n\n");
        luckDescStb2.Append(PlayerManager.instance.GetStatsLuckValue().ToString("F1")).Append("%");

		tradeDescStb1.Append(tradeDescStb2);
		persuasionDescStb1.Append(persuasionDescStb2);
        luckDescStb1.Append(luckDescStb2);

        t_TradeDesc.text = tradeDescStb1.ToString();
		t_PersuasionDesc.text = persuasionDescStb1.ToString();
        t_LuckDesc.text = luckDescStb1.ToString();
    }

    public void OnEnable()
    {
        UpdateUI();
    }

    public int GetTradeNextLevelCost(){
        var currentLevel = PlayerManager.instance.GetStatsTradeLevel();
        return currentLevel * 10;
    }
    public int GetPersuasionNextLevelCost()
    {
        var currentLevel = PlayerManager.instance.GetStatsPersuasionLevel();
        return currentLevel * 10;
    }
    public int GetLuckNextLevelCost()
    {
        var currentLevel = PlayerManager.instance.GetStatsLuckLevel();
        return currentLevel * 10;
    }




}
