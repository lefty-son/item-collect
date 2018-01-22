using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [SerializeField]
    private bool isPlaying;
    public bool IsPlaying
    {
        get
        {
            return isPlaying;
        }
        set {
            isPlaying = value;
        }
    }

    private void Init(){
        IsPlaying = true;
        Farm.instance.Init();
    }

    private void Start()
    {
        if (instance == null) instance = this;
        Init();
    }
}
