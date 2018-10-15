using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    [SerializeField] Text numberOfKillsText;
    [SerializeField] GameObject player;


    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void UpdateCurrentNumberOfKills(int currentKillsNumber)

    {
        
        numberOfKillsText.text = (int.Parse(numberOfKillsText.text) + currentKillsNumber).ToString();
        player.GetComponent<ScoreManager>().UpdateCurrentScore(int.Parse(numberOfKillsText.text));
    }
    

}
