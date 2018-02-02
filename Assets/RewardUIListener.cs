using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardUIListener : MonoBehaviour
{
    #region OBJECT
    public GameObject DAILY_ACHIEVEMENT_1, DAILY_ACHIEVEMENT_2, DAILY_ACHIEVEMENT_3, DAILY_ACHIEVEMENT_4, DAILY_ACHIEVEMENT_5;
    public GameObject QUEST_ACHIEVEMENT_1, QUEST_ACHIEVEMENT_2, QUEST_ACHIEVEMENT_3, QUEST_ACHIEVEMENT_4, QUEST_ACHIEVEMENT_5, QUEST_ACHIEVEMENT_6, QUEST_ACHIEVEMENT_7, QUEST_ACHIEVEMENT_8, QUEST_ACHIEVEMENT_9, QUEST_ACHIEVEMENT_10;
    public GameObject AD_REWARD_1, AD_REWARD_2, AD_REWARD_3;
    public Button b_DAILY_1, b_DAILY_2, b_DAILY_3, b_DAILY_4, b_DAILY_5;
    public Button b_QUEST_1, b_QUEST_2, b_QUEST_3, b_QUEST_4, b_QUEST_5, b_QUEST_6, b_QUEST_7, b_QUEST_8, b_QUEST_9, b_QUEST_10;
    public Button b_AD_1, b_AD_2, b_AD_3;
    #endregion


    private void OnEnable()
    {
        #region QUEST
        /* -------------- -------------- -------------- */
        if (PlayerPrefs.GetInt(PlayerManager.instance.QUEST_10) == 0)
        {
            QUEST_ACHIEVEMENT_10.SetActive(true);
            QUEST_ACHIEVEMENT_10.transform.SetAsFirstSibling();
        }
        if (PlayerPrefs.GetInt(PlayerManager.instance.QUEST_9) == 0)
        {
            QUEST_ACHIEVEMENT_9.SetActive(true);
            QUEST_ACHIEVEMENT_9.transform.SetAsFirstSibling();
        }
        if (PlayerPrefs.GetInt(PlayerManager.instance.QUEST_8) == 0)
        {
            QUEST_ACHIEVEMENT_8.SetActive(true);
            QUEST_ACHIEVEMENT_8.transform.SetAsFirstSibling();
        }
        if (PlayerPrefs.GetInt(PlayerManager.instance.QUEST_7) == 0)
        {
            QUEST_ACHIEVEMENT_7.SetActive(true);
            QUEST_ACHIEVEMENT_7.transform.SetAsFirstSibling();
        }
        if (PlayerPrefs.GetInt(PlayerManager.instance.QUEST_6) == 0)
        {
            QUEST_ACHIEVEMENT_6.SetActive(true);
            QUEST_ACHIEVEMENT_6.transform.SetAsFirstSibling();
        }
        if (PlayerPrefs.GetInt(PlayerManager.instance.QUEST_5) == 0)
        {
            QUEST_ACHIEVEMENT_5.SetActive(true);
            QUEST_ACHIEVEMENT_5.transform.SetAsFirstSibling();
        }
        if (PlayerPrefs.GetInt(PlayerManager.instance.QUEST_4) == 0)
        {
            QUEST_ACHIEVEMENT_4.SetActive(true);
            QUEST_ACHIEVEMENT_4.transform.SetAsFirstSibling();
        }
        if (PlayerPrefs.GetInt(PlayerManager.instance.QUEST_3) == 0)
        {
            QUEST_ACHIEVEMENT_3.SetActive(true);
            QUEST_ACHIEVEMENT_3.transform.SetAsFirstSibling();
        }
        if (PlayerPrefs.GetInt(PlayerManager.instance.QUEST_2) == 0)
        {
            QUEST_ACHIEVEMENT_2.SetActive(true);
            QUEST_ACHIEVEMENT_2.transform.SetAsFirstSibling();
        }
        if (PlayerPrefs.GetInt(PlayerManager.instance.QUEST_1) == 0)
        {
            QUEST_ACHIEVEMENT_1.SetActive(true);
            QUEST_ACHIEVEMENT_1.transform.SetAsFirstSibling();
        }
        #endregion


        #region DAILY
        /* -------------- -------------- -------------- */
        if (PlayerPrefs.GetInt(PlayerManager.instance.DAILY_5) == 0)
        {
            DAILY_ACHIEVEMENT_5.SetActive(true);
            DAILY_ACHIEVEMENT_5.transform.SetAsFirstSibling();
        }
        if (PlayerPrefs.GetInt(PlayerManager.instance.DAILY_4) == 0)
        {
            DAILY_ACHIEVEMENT_4.SetActive(true);
            DAILY_ACHIEVEMENT_4.transform.SetAsFirstSibling();
        }
        if (PlayerPrefs.GetInt(PlayerManager.instance.DAILY_3) == 0)
        {
            DAILY_ACHIEVEMENT_3.SetActive(true);
            DAILY_ACHIEVEMENT_3.transform.SetAsFirstSibling();
        }
        if (PlayerPrefs.GetInt(PlayerManager.instance.DAILY_2) == 0)
        {
            DAILY_ACHIEVEMENT_2.SetActive(true);
            DAILY_ACHIEVEMENT_2.transform.SetAsFirstSibling();
        }
        if (PlayerPrefs.GetInt(PlayerManager.instance.DAILY_1) == 0)
        {
            DAILY_ACHIEVEMENT_1.SetActive(true);
            DAILY_ACHIEVEMENT_1.transform.SetAsFirstSibling();
        }
        #endregion


        #region AD
        /* -------------- -------------- -------------- */
        if (PlayerPrefs.GetInt(PlayerManager.instance.AD_3) == 0)
        {
            AD_REWARD_3.SetActive(true);
            AD_REWARD_3.transform.SetAsFirstSibling();
        }
        if (PlayerPrefs.GetInt(PlayerManager.instance.AD_2) == 0)
        {
            AD_REWARD_2.SetActive(true);
            AD_REWARD_2.transform.SetAsFirstSibling();
        }
        if (PlayerPrefs.GetInt(PlayerManager.instance.AD_1) == 0)
        {
            AD_REWARD_1.SetActive(true);
            AD_REWARD_1.transform.SetAsFirstSibling();
        }
        #endregion
    }


}
