using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnResultPositionSetter : MonoBehaviour {

    private RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    private void OnEnable()
    {
        transform.localScale = Vector3.one;
        rect.offsetMax = Vector3.zero;
        rect.offsetMin = Vector3.zero;
    }
}
