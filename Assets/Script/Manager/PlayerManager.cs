using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public static PlayerManager instance;

    public enum DEVICE_LANGUAGE
    {
        EN, KR, JP, CN, CNT
    }
	public DEVICE_LANGUAGE LANGUAGE;

    #region CONST
	private readonly int DEFAULT_BAG_SIZE   = 6;
    private readonly int DAILY_1_ITEM_RARE_LIMIT = 3;
    private readonly int DAILY_2_ITEM_LGD_LIMIT = 20;
    private readonly int DAILY_3_ITEM_ANCIENT_LIMIT = 5;
    private readonly int DAILY_4_FORGE_SUCCESS_LIMIT = 5;
    private readonly int DAILY_5_FORGE_FAILED_LIMIT = 1;
    #endregion


    #region KEY
    private readonly string COOKIE = "0b16b6d29f92bc32f417f14f2c16ea2a";

    private readonly string TRADE_LEVEL = "3a5373f7c1598b9e251273833f5bca21";
    private readonly string PERSUASION_LEVEL = "8ab217095857bd6030720149cba0761c";
    private readonly string BAG_SIZE_LEVEL = "32510ca559c0ecdffe8438199b20c85a";
    private readonly string LUCK_LEVEL = "01de7201c286a45d623e47cf81a20c6c";

    private readonly string LOCATION = "71233d73cc90bba8f4d5bbea0792e551";

    public readonly string DAILY_1 = "c5f5aa9b2a49a6f88e06b84317af44ce";
    public readonly string DAILY_2 = "b5d073613d9531900c9bfadb9a6888c4";
    public readonly string DAILY_3 = "40c36dd877f80c51c046fca0a66daf1d";
    public readonly string DAILY_4 = "b56c7de3029ef6e7bef4fb45f824fc48";
    public readonly string DAILY_5 = "15eba0b09a52195bd91822897c777cea";

    public readonly string QUEST_1 = "b2009607b109d21e0c8f0339c734b24a";
    public readonly string QUEST_2 = "124e117b130b12c1b4d92b9c1a8ca2d5";
    public readonly string QUEST_3 = "fea7a5cf8ed75e68e6deba27abf26018";
    public readonly string QUEST_4 = "9b0d09c29566b72cf28d70870f8c559f";
    public readonly string QUEST_5 = "5d7dcfd35ec264b47918b905853b1830";
    public readonly string QUEST_6 = "c2f098a2bd1264cc2ce7741cfb002f8d";
    public readonly string QUEST_7 = "1496d77eec1647d5d3a8da7257451fb3";
    public readonly string QUEST_8 = "f3cae0f638d13ba16ec545f54fec12c3";
    public readonly string QUEST_9 = "f99eadfd930b7235ca6cc72565cd0541";
    public readonly string QUEST_10 = "6289d92454425becca4fbf10daad417c";

    public readonly string AD_1 = "8da8d962c04126a69aa4393d5430e712";
    public readonly string AD_2 = "91326443003ae89c26d7a864322c20eb";
    public readonly string AD_3 = "e319e0972382cd525d9f7b340e7cd8e8";

    private readonly string NOTIFICATION = "9814d942b7e24870084a3dce24867ab3";

    /* DAILY */
    private readonly string ITEM_COUNT_RARE = "09531d47c07325ce91a5fb40370f0a1f";
    private readonly string ITEM_COUNT_LGD = "3f533f469948c7ffc85b70df6b37442b";
    private readonly string ITEM_COUNT_ANCIENT = "7da45c5be732a77867749995e25a19d7";
    private readonly string FORGE_SUCCESS_COUNT = "ba070632e13dee203ee70503f0532944";
    private readonly string FORGE_FAILED_COUNT = "c2a1c3a77d2088fc8f8d22fc3352e351";

    #endregion


    private void Awake()
    {
        if (instance == null) instance = this;
        CheckLanguage();
        CheckCookie();
    }

    private void CheckLanguage(){
        if (Application.systemLanguage == SystemLanguage.English)
        {
            LANGUAGE = DEVICE_LANGUAGE.EN;
        }
        else if (Application.systemLanguage == SystemLanguage.Korean)
        {
            LANGUAGE = DEVICE_LANGUAGE.KR;
        }
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			LANGUAGE = DEVICE_LANGUAGE.JP;
		}
        else if (Application.systemLanguage == SystemLanguage.ChineseSimplified)
        {
            LANGUAGE = DEVICE_LANGUAGE.CN;
        }
        else if (Application.systemLanguage == SystemLanguage.ChineseTraditional)
        {
            LANGUAGE = DEVICE_LANGUAGE.CNT;
        }
        else
        {
            LANGUAGE = DEVICE_LANGUAGE.EN;
        }
    }

    private void CheckCookie(){
        if(PlayerPrefs.HasKey(COOKIE)){
            // Already
        }
        else {
            // New user
            PlayerPrefs.SetInt(COOKIE, 1);

            CurrencyManager.instance.InitGold();

            PlayerPrefs.SetInt(TRADE_LEVEL, 0);
            PlayerPrefs.SetInt(PERSUASION_LEVEL, 0);
            PlayerPrefs.SetInt(BAG_SIZE_LEVEL, 0);
            PlayerPrefs.SetInt(LUCK_LEVEL, 0);
            PlayerPrefs.SetInt(LOCATION, 0);

            PlayerPrefs.SetInt(QUEST_1, 0);
            PlayerPrefs.SetInt(QUEST_2, 0);
            PlayerPrefs.SetInt(QUEST_3, 0);
            PlayerPrefs.SetInt(QUEST_4, 0);
            PlayerPrefs.SetInt(QUEST_5, 0);
            PlayerPrefs.SetInt(QUEST_6, 0);
            PlayerPrefs.SetInt(QUEST_7, 0);
            PlayerPrefs.SetInt(QUEST_8, 0);
            PlayerPrefs.SetInt(QUEST_9, 0);
            PlayerPrefs.SetInt(QUEST_10, 0);
            PlayerPrefs.SetInt(AD_1, 0);
            PlayerPrefs.SetInt(AD_2, 0);
            PlayerPrefs.SetInt(AD_3, 0);

            PlayerPrefs.SetInt(NOTIFICATION, 0);

            /* DAILY */
            PlayerPrefs.SetInt(ITEM_COUNT_RARE, 0);
            PlayerPrefs.SetInt(ITEM_COUNT_LGD, 0);
            PlayerPrefs.SetInt(ITEM_COUNT_ANCIENT, 0);
			PlayerPrefs.SetInt(FORGE_SUCCESS_COUNT, 0);
            PlayerPrefs.SetInt(FORGE_FAILED_COUNT, 0);
        }
    }


    #region STATS GETTER

    public int GetStatsTradeLevel(){
        return PlayerPrefs.GetInt(TRADE_LEVEL);
    }
    public int GetStatsPersuasionLevel(){
        return PlayerPrefs.GetInt(PERSUASION_LEVEL);
    }
    public int GetStatsBagSizeLevel(){
        return PlayerPrefs.GetInt(BAG_SIZE_LEVEL);
    }
    public int GetStatsLuckLevel(){
        return PlayerPrefs.GetInt(LUCK_LEVEL);
    }

    public float GetStatsTradeValue(){
        var level = GetStatsTradeLevel();
        float trade = 1f - (100f / (float)(100 + level)) * 50f + 50;
        return trade * 0.01f;
    }
    public float GetStatsPersuasionValue(){
        var level = GetStatsPersuasionLevel();
        float persuasion = 1f - (100f / (float)(100 + level)) * 50f + 50;
        return persuasion;
    }
    public int GetStatsBagSizeValue(){
        return GetStatsBagSizeLevel() + DEFAULT_BAG_SIZE;
    }
    public float GetStatsLuckValue(){
        var level = GetStatsLuckLevel();
        float luck = 1f - (100f / (float)(100 + level)) * 50f + 50;
        return  luck;
    }

    public int GetCurrentLocation(){
        return PlayerPrefs.GetInt(LOCATION);
    }

    public int GetNotification(){
        return PlayerPrefs.GetInt(NOTIFICATION);
    }
    #endregion

    #region STATS SETTER
    public void SetStatsTradeLevelUp(){
        PlayerPrefs.SetInt(TRADE_LEVEL, GetStatsTradeLevel() + 1);
	}
    public void SetStatsPersuasionLevelUp(){
        PlayerPrefs.SetInt(PERSUASION_LEVEL, GetStatsPersuasionLevel() + 1);
    }
    public void SetStatsBagSizeLevelUp(){
        PlayerPrefs.SetInt(BAG_SIZE_LEVEL, GetStatsBagSizeLevel() + 1);
	}
    public void SetStatsLuckLevelUp(){
        PlayerPrefs.SetInt(LUCK_LEVEL, GetStatsLuckLevel() + 1);
    }
    public void SetCurrentLocation(int value){
        PlayerPrefs.SetInt(LOCATION, value);
		FindObjectOfType<TextCurrentLocationHolder>().OnEnable();
    }
    #endregion


    #region GET, PLUS REWARDS
    public void PlusNotificationCount()
    {
        PlayerPrefs.SetInt(NOTIFICATION, GetNotification() + 1);
        UIManager.instance.OnNotification();
    }
    public void MinusNotificationCount(){
        PlayerPrefs.SetInt(NOTIFICATION, GetNotification() - 1);
        if(GetNotification() <= 0){
            UIManager.instance.OffNotification();
        }
    }
    /* DAILY */
    public int GetItemCountRare()
    {
        return PlayerPrefs.GetInt(ITEM_COUNT_RARE);
    }
    public int GetItemCountLegendary()
    {
        return PlayerPrefs.GetInt(ITEM_COUNT_LGD);
    }
    public int GetItemCountAncient()
    {
        return PlayerPrefs.GetInt(ITEM_COUNT_ANCIENT);
    }
    public int GetForgeSuccessCount()
    {
        return PlayerPrefs.GetInt(FORGE_SUCCESS_COUNT);
    }
    public int GetForgeFailedCount()
    {
        return PlayerPrefs.GetInt(FORGE_FAILED_COUNT);
    }
    public void PlusItemCountRare(){
        PlayerPrefs.SetInt(ITEM_COUNT_RARE, GetItemCountRare() + 1);
        if(GetItemCountRare() >= DAILY_1_ITEM_RARE_LIMIT && PlayerPrefs.GetInt(DAILY_1) == 0){
            PlusNotificationCount();
            SetReadyToGetDailyRewards(1);
        }
    }
    public void PlusItemCountLegendary()
    {
        PlayerPrefs.SetInt(ITEM_COUNT_LGD, GetItemCountLegendary() + 1);
        if(GetItemCountLegendary() >= DAILY_2_ITEM_LGD_LIMIT && PlayerPrefs.GetInt(DAILY_2) == 0){
            PlusNotificationCount();
            SetReadyToGetDailyRewards(2);
        }
    }
    public void PlusItemCountAncient()
    {
        PlayerPrefs.SetInt(ITEM_COUNT_ANCIENT, GetItemCountAncient() + 1);
        if(GetItemCountAncient() >= DAILY_3_ITEM_ANCIENT_LIMIT && PlayerPrefs.GetInt(DAILY_3) == 0){
            PlusNotificationCount();
            SetReadyToGetDailyRewards(3);
        }
    }
    public void PlusForgeSuccessCount(){
        PlayerPrefs.SetInt(FORGE_SUCCESS_COUNT, GetForgeSuccessCount() + 1);
        if(GetForgeSuccessCount() >= DAILY_4_FORGE_SUCCESS_LIMIT && PlayerPrefs.GetInt(DAILY_4) == 0){
            PlusNotificationCount();
            SetReadyToGetDailyRewards(4);
        }
    }
    public void PlusForgeFailedCount(){
        PlayerPrefs.SetInt(FORGE_FAILED_COUNT, GetForgeFailedCount() + 1);
        if(GetForgeFailedCount() >= DAILY_5_FORGE_FAILED_LIMIT && PlayerPrefs.GetInt(DAILY_5) == 0){
            PlusNotificationCount();
            SetReadyToGetDailyRewards(5);
        }
    }
    #endregion

    #region RECEIVE REWARDS
    public void ReceiveDailyRewards(int number){
        if(number == 1){
            
        }
        else if (number == 2)
        {

        }
        else if (number == 3)
        {

        }
        else if (number == 4)
        {

        }
        else if (number == 5)
        {

        }
        MinusNotificationCount();
        ClearDailyRewards(number);
    }
    public void ReceiveQuestRewards(int number)
    {
        if (number == 1)
        {

        }
        else if (number == 2)
        {

        }
        else if (number == 3)
        {

        }
        else if (number == 4)
        {

        }
        else if (number == 5)
        {

        }
        else if (number == 6)
        {

        }
        else if (number == 7)
        {

        }
        else if (number == 8)
        {

        }
        else if (number == 9)
        {

        }
        else if (number == 10)
        {

        }
        MinusNotificationCount();
        ClearQuestRewards(number);
    }
    public void ReceiveAdRewards(int number){
        if (number == 1)
        {

        }
        else if (number == 2)
        {

        }
        else if (number == 3)
        {

        }
        MinusNotificationCount();
        ClearAdRewards(number);
    }
    #endregion


    #region READY TO GET REWARDS
    private void SetReadyToGetDailyRewards(int number){
        if (number == 1)
        {
            PlayerPrefs.SetInt(DAILY_1, 1);
        }
        else if (number == 2)
        {
            PlayerPrefs.SetInt(DAILY_2, 1);
        }
        else if (number == 3)
        {
            PlayerPrefs.SetInt(DAILY_3, 1);
        }
        else if (number == 4)
        {
            PlayerPrefs.SetInt(DAILY_4, 1);
        }
        else if (number == 5)
        {
            PlayerPrefs.SetInt(DAILY_5, 1);
        }
    }
    private void SetReadyToGetQuestRewards(int number){
        if (number == 1)
        {
            PlayerPrefs.SetInt(QUEST_1, 1);
        }
        else if (number == 2)
        {
            PlayerPrefs.SetInt(QUEST_2, 1);
        }
        else if (number == 3)
        {
            PlayerPrefs.SetInt(QUEST_3, 1);
        }
        else if (number == 4)
        {
            PlayerPrefs.SetInt(QUEST_4, 1);
        }
        else if (number == 5)
        {
            PlayerPrefs.SetInt(QUEST_5, 1);
        }
        else if (number == 6)
        {
            PlayerPrefs.SetInt(QUEST_6, 1);
        }
        else if (number == 7)
        {
            PlayerPrefs.SetInt(QUEST_7, 1);
        }
        else if (number == 8)
        {
            PlayerPrefs.SetInt(QUEST_8, 1);
        }
        else if (number == 9)
        {
            PlayerPrefs.SetInt(QUEST_9, 1);
        }
        else if (number == 10)
        {
            PlayerPrefs.SetInt(QUEST_10, 1);
        }
    }
    private void SetReadyToGetAdRewards(int number){
        if (number == 1)
        {
            PlayerPrefs.SetInt(AD_1, 1);
        }
        else if (number == 2)
        {
            PlayerPrefs.SetInt(AD_2, 1);
        }
        else if (number == 3)
        {
            PlayerPrefs.SetInt(AD_3, 1);
        }
    }
    #endregion


    #region CLEAR REWARDS
    private void ClearDailyRewards(int number)
    {
        if (number == 1)
        {
            PlayerPrefs.SetInt(DAILY_1, 0);
        }
        else if (number == 2)
        {
            PlayerPrefs.SetInt(DAILY_2, 0);
        }
        else if (number == 3)
        {
            PlayerPrefs.SetInt(DAILY_3, 0);
        }
        else if (number == 4)
        {
            PlayerPrefs.SetInt(DAILY_4, 0);
        }
        else if (number == 5)
        {
            PlayerPrefs.SetInt(DAILY_5, 0);
        }
    }

    private void ClearQuestRewards(int number)
    {
        if (number == 1)
        {
            PlayerPrefs.SetInt(QUEST_1, 0);
        }
        else if (number == 2)
        {
            PlayerPrefs.SetInt(QUEST_2, 0);
        }
        else if (number == 3)
        {
            PlayerPrefs.SetInt(QUEST_3, 0);
        }
        else if (number == 4)
        {
            PlayerPrefs.SetInt(QUEST_4, 0);
        }
        else if (number == 5)
        {
            PlayerPrefs.SetInt(QUEST_5, 0);
        }
        else if (number == 6)
        {
            PlayerPrefs.SetInt(QUEST_6, 0);
        }
        else if (number == 7)
        {
            PlayerPrefs.SetInt(QUEST_7, 0);
        }
        else if (number == 8)
        {
            PlayerPrefs.SetInt(QUEST_8, 0);
        }
        else if (number == 9)
        {
            PlayerPrefs.SetInt(QUEST_9, 0);
        }
        else if (number == 10)
        {
            PlayerPrefs.SetInt(QUEST_10, 0);
        }
    }

    private void ClearAdRewards(int number)
    {
        if (number == 1)
        {
            PlayerPrefs.SetInt(AD_1, 0);
        }
        else if (number == 2)
        {
            PlayerPrefs.SetInt(AD_2, 0);
        }
        else if (number == 3)
        {
            PlayerPrefs.SetInt(AD_3, 0);
        }
    }
    #endregion




    public void DebugDeleteAll(){
        PlayerPrefs.DeleteAll();
        Debug.Log("Deleted");
        CheckCookie();
    }
}
