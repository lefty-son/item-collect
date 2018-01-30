using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextCurrentLocationHolder : MonoBehaviour {
    private Text t;

    private void Awake()
    {
        t = GetComponent<Text>();
    }

    public void OnEnable()
    {
        t.text = Localizer.instance.GetTownName();
    }

}
