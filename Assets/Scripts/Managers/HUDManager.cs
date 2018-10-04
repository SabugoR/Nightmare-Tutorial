using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    [SerializeField] Text numberOfKillsText;
    string killsText = "Kills: ";
    // Use this for initialization
    void Start () {
        numberOfKillsText.text = killsText + "0";
    }

    // Update is called once per frame
    void Update () {

    }

    public void UpdateCurrentNumberOfKills(int currentKillsNumber)
    {
        numberOfKillsText.text = killsText + currentKillsNumber;
    }

}
