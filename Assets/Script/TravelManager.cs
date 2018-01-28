using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TravelManager : MonoBehaviour {
    public static TravelManager instance;

    public enum TOWN {
        A, B, C, FIELD
    }

    public TOWN town;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void ChangeSceneToTown(){
        //if(town == TOWN.A){
            
        //}
        //else if(town == TOWN.B){
            
        //}
        //else if(town == TOWN.C){
            
        //}
        //else {
            
        //}
        SceneManager.LoadScene("Town");
    }

    public void MoveToA()
    {
        town = TOWN.A;
        UIManager.instance.StartFadeToTravel();
    }

    public void MoveToB()
    {
        town = TOWN.B;
        UIManager.instance.StartFadeToTravel();
    }

    public void MoveToC()
    {
        town = TOWN.C;
        UIManager.instance.StartFadeToTravel();
    }
}
