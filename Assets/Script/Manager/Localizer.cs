using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localizer : MonoBehaviour {
    public static Localizer instance;

    private readonly string item001 = "item001";
	private readonly string item002 = "item003";
    private readonly string item003 = "item002";

    private Dictionary<string, string> dict;

    private void Awake()
    {
        if (instance == null) instance = this;
        dict = new Dictionary<string, string>();
        FillDictionary();
    }

    private void FillDictionary(){
        dict.Add(item001, "Sword");
        dict.Add(item002, "Knife");
        dict.Add(item003, "Dagger");
    }

    public string GetTextFromLocal(string _key)
    {
        return dict[_key];
    }
}
