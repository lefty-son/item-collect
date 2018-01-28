using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour {
    public static CurrencyManager instance;

    public Text t_Gold, t_Diamond;

    public float duration = 0.5f;

    private readonly string GOLD = "2c0898822ab3baf7f93bea86648adb26";
    private readonly int GOLD_INIT_VALUE = 1000;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void OnEnable()
    {
        UpdateGoldUI();
    }

    public void UpdateGoldUI(){
        StopCoroutine("CountTo");
        StartCoroutine("CountTo", GetGold());
    }

    public void InitGold(){
        PlayerPrefs.SetInt(GOLD, GOLD_INIT_VALUE);
    }

    public int GetGold(){
        return PlayerPrefs.GetInt(GOLD);
    }

    public void SetGoldByAllocating(int value){
		UpdateGoldUI();
        PlayerPrefs.SetInt(GOLD, value);
    }

    public void PlusGoldByValue(int value){
        UpdateGoldUI();
        PlayerPrefs.SetInt(GOLD, GetGold() + value);
    }

    public void MinusGoldByValue(int value){
		UpdateGoldUI();
        PlayerPrefs.SetInt(GOLD, GetGold() - value);
    }

    public bool CheckGoldAffordable(int value){
        if(GetGold() >= value){
            return true;
        }
        else {
            return false;
        }
    }

    IEnumerator CountTo(int _start)
    {
        int start = _start;
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            _start = (int)Mathf.Lerp(start, GetGold(), progress);
            t_Gold.text = _start.ToString();
            yield return null;
        }
        t_Gold.text = GetGold().ToString();
    }
}
