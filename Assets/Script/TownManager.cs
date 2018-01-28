using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TownManager : MonoBehaviour {

    public static TownManager instance;

    public GameObject p_Plaza, p_Tavern, p_Shop;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void OnPlaza(){
        p_Plaza.SetActive(true);
        p_Tavern.SetActive(false);
        p_Shop.SetActive(false);
    }

    public void OnTavern(){
		p_Tavern.SetActive(true);
        p_Plaza.SetActive(false);
        p_Shop.SetActive(false);
    }

    public void OnShop(){
		p_Shop.SetActive(true);
		p_Tavern.SetActive(false);
        p_Plaza.SetActive(false);
    }

    public void OffAll(){
        p_Shop.SetActive(false);
        p_Tavern.SetActive(false);
        p_Plaza.SetActive(false);
    }

    public void OnLeaving(){
        
    }

}
