using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Inventory : MonoBehaviour {

    public static Inventory instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

}







