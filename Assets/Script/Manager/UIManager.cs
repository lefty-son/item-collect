using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Linq;
using JetBrains.Annotations;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public AnimationCurve curvez, travelCurve;


    /* Under Panel */
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

    public Image i_Fading;

    private void Awake()
    {
        if (instance == null) instance = this;

        b_Inventory.onClick.AddListener(OnInventory);
        b_Growth.onClick.AddListener(OnGrowth);
        b_Travel.onClick.AddListener(OnTravel);
        b_Reward.onClick.AddListener(OnReward);
        b_Settings.onClick.AddListener(OnSettings);
    }

    public void StartFadeOut(){
        StartCoroutine(FadeOut());
    }

    public void StartFadeToTravel(){
        StartCoroutine(FadeToTravel());
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

        TravelManager.instance.ChangeSceneToTown();

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

    public void OffAllUnderPanels()
    {
        p_Inventory.SetActive(false);
        p_Growth.SetActive(false);
        p_Travel.SetActive(false);
        p_Reward.SetActive(false);
        p_Settings.SetActive(false);
    }

    public void OnInventory()
    {
        p_Inventory.SetActive(true);

        p_Growth.SetActive(false);
        p_Travel.SetActive(false);
        p_Reward.SetActive(false);
        p_Settings.SetActive(false);
    }

    public void OnGrowth()
    {
        p_Growth.SetActive(true);

        p_Inventory.SetActive(false);
        p_Travel.SetActive(false);
        p_Reward.SetActive(false);
        p_Settings.SetActive(false);
    }

    public void OnTravel()
    {
        p_Travel.SetActive(true);

        p_Inventory.SetActive(false);
        p_Growth.SetActive(false);
        p_Reward.SetActive(false);
        p_Settings.SetActive(false);

    }

    public void OnReward()
    {
        p_Reward.SetActive(true);

        p_Inventory.SetActive(false);
        p_Growth.SetActive(false);
        p_Travel.SetActive(false);
        p_Settings.SetActive(false);
    }

    public void OnSettings()
    {
        p_Settings.SetActive(true);

        p_Inventory.SetActive(false);
        p_Growth.SetActive(false);
        p_Travel.SetActive(false);
        p_Reward.SetActive(false);
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


    #region Forge


    public void OnForge(){
        p_Forge.SetActive(true);
    }

    public void OffForge(){
        p_Forge.SetActive(false);
    }

    #endregion


}
