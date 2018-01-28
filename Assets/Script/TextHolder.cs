using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHolder : MonoBehaviour {

    protected Text t;

    private void Awake()
    {
        t = GetComponent<Text>();
    }

    private void OnEnable()
    {
        var value = Localizer.instance.GetTextFromLocal(gameObject.name);
        t.text = value;
    }
}
