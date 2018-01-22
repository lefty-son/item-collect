using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager instance;

    public Button b_Inventory, b_Growth, b_Travel, b_Reward, b_Settings;
    public GameObject p_Inventory, p_Growth, p_Travel, p_Reward, p_Settings;
    public GameObject p_Farm;

    private void Awake()
    {
        if (instance == null) instance = this;

        b_Inventory.onClick.AddListener(OnInventory);
        b_Growth.onClick.AddListener(OnGrowth);
        b_Travel.onClick.AddListener(OnTravel);
        b_Reward.onClick.AddListener(OnReward);
        b_Settings.onClick.AddListener(OnSettings);
    }

    public void OffAllUnderPanels(){
        p_Inventory.SetActive(false);
        p_Growth.SetActive(false);
        p_Travel.SetActive(false);
        p_Reward.SetActive(false);
        p_Settings.SetActive(false);
    }

    public void OnInventory(){
        p_Inventory.SetActive(true);
        p_Inventory.transform.SetAsLastSibling();

        p_Growth.SetActive(false);
        p_Travel.SetActive(false);
        p_Reward.SetActive(false);
        p_Settings.SetActive(false);
    }

    public void OnGrowth(){
        p_Growth.SetActive(true);
        p_Growth.transform.SetAsLastSibling();

        p_Inventory.SetActive(false);
        p_Travel.SetActive(false);
        p_Reward.SetActive(false);
        p_Settings.SetActive(false);
    }

    public void OnTravel()
    {
        p_Travel.SetActive(true);
        p_Travel.transform.SetAsLastSibling();

        p_Inventory.SetActive(false);
        p_Growth.SetActive(false);
        p_Reward.SetActive(false);
        p_Settings.SetActive(false);

    }

    public void OnReward()
    {
        p_Reward.SetActive(true);
        p_Reward.transform.SetAsLastSibling();

        p_Inventory.SetActive(false);
        p_Growth.SetActive(false);
        p_Travel.SetActive(false);
        p_Settings.SetActive(false);
    }

    public void OnSettings()
    {
        p_Settings.SetActive(true);
        p_Settings.transform.SetAsLastSibling();

        p_Inventory.SetActive(false);
        p_Growth.SetActive(false);
        p_Travel.SetActive(false);
        p_Reward.SetActive(false);
    }

}
