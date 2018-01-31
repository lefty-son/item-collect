using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public AnimationCurve curvez, travelCurve;

    public enum CurrentUI
    {
        INVENTORY, GROWTH, TRAVEL, REWARD, SETTINGS, NONE
    }

    public CurrentUI currentUI;

    /* Under Panel */
    public AnimationClip c_PanelOut, c_PanelIn;
    public Animation a_Inventory, a_Growth, a_Travel, a_Reward, a_Settings;
    public Button b_Inventory, b_Growth, b_Travel, b_Reward, b_Settings;
    public GameObject p_Inventory, p_Growth, p_Travel, p_Reward, p_Settings;
    /* ----------- */

    /* Farm Panel */
    public Animation a_Farm;
    public GameObject p_Farm, p_Discover, p_DiscoverHelper;
    /* ---------- */

    /* Forge Panel */
    public GameObject p_Forge;
    /* ----------- */

    /* Sell Panel */
    public GameObject p_Sell;
    /* ---------- */

    public Image i_Fading;

    private void Awake()
    {
        if (instance == null) instance = this;

        b_Inventory.onClick.AddListener(OnInventory);
        b_Growth.onClick.AddListener(OnGrowth);
        b_Travel.onClick.AddListener(OnTravel);
        b_Reward.onClick.AddListener(OnReward);
        b_Settings.onClick.AddListener(OnSettings);

        currentUI = CurrentUI.NONE;
    }

    public void StartFadeOut(){
        StartCoroutine(FadeOut());
    }

	private IEnumerator FadeOut()
	{
		i_Fading.color = new Color(0.7f, 0.7f, 0.7f, 1f);
		var t = 0f;
		i_Fading.gameObject.SetActive(true);
		while (t <= 2f)
		{
			t += Time.deltaTime;
			yield return null;
			i_Fading.color = new Color(0.7f, 0.7f, 0.7f, curvez.Evaluate(2f - t));
		}
		i_Fading.gameObject.SetActive(false);
	}

    public void StartFadeToTravel(){
        StartCoroutine(FadeToTravel());
    }

    private IEnumerator FadeToTravel()
    {
        i_Fading.color = new Color(0.7f, 0.7f, 0.7f, 0f);
        var t = 0f;
        i_Fading.gameObject.SetActive(true);
		while (t <= 1f)
		{
			t += Time.deltaTime;
			yield return null;
            i_Fading.color = new Color(0.7f, 0.7f, 0.7f, travelCurve.Evaluate(t / 1));
		}

        UIManager.instance.OffAllUnderPanels();

        yield return new WaitForSeconds(2f);

        t = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime;
            yield return null;
            i_Fading.color = new Color(0.7f, 0.7f, 0.7f, travelCurve.Evaluate(1f - t));
        }
        i_Fading.gameObject.SetActive(false);
    }


    #region Under Panel

    private void AnimateClose(){
        if(currentUI == CurrentUI.INVENTORY){
            a_Inventory.clip = c_PanelOut;
            a_Inventory.Play();
        }
        else if (currentUI == CurrentUI.GROWTH)
        {
            a_Growth.clip = c_PanelOut;
            a_Growth.Play();
        }
        else if (currentUI == CurrentUI.TRAVEL)
        {
            a_Travel.clip = c_PanelOut;
            a_Travel.Play();
        }
        else if (currentUI == CurrentUI.REWARD)
        {
            a_Reward.clip = c_PanelOut;
            a_Reward.Play();
        }
        else
        {
            a_Settings.clip = c_PanelOut;
            a_Settings.Play();
        }
    }

    public void OffAllUnderPanels()
    {
        currentUI = CurrentUI.NONE;
        p_Inventory.SetActive(false);
        p_Growth.SetActive(false);
        p_Travel.SetActive(false);
        p_Reward.SetActive(false);
        p_Settings.SetActive(false);
        b_Growth.interactable = true;
        b_Reward.interactable = true;
        b_Travel.interactable = true;
        b_Settings.interactable = true;
        b_Inventory.interactable = true;
    }

    public void OnInventory()
    {
		b_Inventory.interactable = false;
        AnimateClose();
        currentUI = CurrentUI.INVENTORY;
        p_Inventory.SetActive(true);
        a_Inventory.clip = c_PanelIn;
        a_Inventory.Play();

        b_Growth.interactable = true;
        b_Reward.interactable = true;
        b_Travel.interactable = true;
        b_Settings.interactable = true;
        //b_Inventory.interactable = true;

        //p_Growth.SetActive(false);
        //p_Travel.SetActive(false);
        //p_Reward.SetActive(false);
        //p_Settings.SetActive(false);
    }

    public void OnGrowth()
    {
        b_Growth.interactable = false;
        AnimateClose();
        currentUI = CurrentUI.GROWTH;
        p_Growth.SetActive(true);
        a_Growth.clip = c_PanelIn;
        a_Growth.Play();

        //b_Growth.interactable = true;
        b_Reward.interactable = true;
        b_Travel.interactable = true;
        b_Settings.interactable = true;
        b_Inventory.interactable = true;

        //p_Inventory.SetActive(false);
        //p_Travel.SetActive(false);
        //p_Reward.SetActive(false);
        //p_Settings.SetActive(false);
    }

    public void OnTravel()
    {
        b_Travel.interactable = false;
        AnimateClose();
        currentUI = CurrentUI.TRAVEL;
        p_Travel.SetActive(true);
        a_Travel.clip = c_PanelIn;
        a_Travel.Play();

        b_Growth.interactable = true;
        b_Reward.interactable = true;
        //b_Travel.interactable = true;
        b_Settings.interactable = true;
        b_Inventory.interactable = true;

        //p_Inventory.SetActive(false);
        //p_Growth.SetActive(false);
        //p_Reward.SetActive(false);
        //p_Settings.SetActive(false);

    }

    public void OnReward()
    {
        b_Reward.interactable = false;
        AnimateClose();
        currentUI = CurrentUI.REWARD;
        p_Reward.SetActive(true);
        a_Reward.clip = c_PanelIn;
        a_Reward.Play();

        b_Growth.interactable = true;
        //b_Reward.interactable = true;
        b_Travel.interactable = true;
        b_Settings.interactable = true;
        b_Inventory.interactable = true;

        //p_Inventory.SetActive(false);
        //p_Growth.SetActive(false);
        //p_Travel.SetActive(false);
        //p_Settings.SetActive(false);
    }

    public void OnSettings()
    {
        b_Settings.interactable = false;
        AnimateClose();
        currentUI = CurrentUI.SETTINGS;
        p_Settings.SetActive(true);
        a_Settings.clip = c_PanelIn;
        a_Settings.Play();

        b_Growth.interactable = true;
        b_Reward.interactable = true;
        b_Travel.interactable = true;
        //b_Settings.interactable = true;
        b_Inventory.interactable = true;

        //p_Inventory.SetActive(false);
        //p_Growth.SetActive(false);
        //p_Travel.SetActive(false);
        //p_Reward.SetActive(false);
    }

    #endregion


    #region Farm Panel

    public void OnFarm()
    {
        p_Farm.SetActive(true);
        a_Farm.Play();
        Farm.instance.Init();
    }

    public void OffFarm()
    {
        p_Farm.SetActive(false);
    }

    public void OnDiscover()
    {
        p_Discover.SetActive(true);
        p_DiscoverHelper.SetActive(true);
    }

    public void OffDiscover()
    {
        p_Discover.SetActive(false);
        p_DiscoverHelper.SetActive(false);
    }

    private void OnConfirm()
    {
        OffDiscover();
    }

    public void OnClickArchive()
    {
        Inventory.instance.AddItem(Farm.instance.GetTempItem());
        OnConfirm();
    }

    #endregion


    #region Sell

    public void OnSell(){
        p_Sell.SetActive(true);
    }

    public void OffSell(){
        p_Sell.SetActive(false);
    }

    #endregion



    #region Forge


    public void OnForge(){
        p_Forge.SetActive(true);
    }

    public void OffForge(){
        p_Forge.SetActive(false);
    }

    #endregion


}
