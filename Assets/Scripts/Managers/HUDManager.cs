using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    [SerializeField] Text numberOfKillsText;
    [SerializeField] Text numberOfHealthLeft;

    string killsText = "Kills: ";
    string healthText = "Health: ";

    // Use this for initialization
    void Start () {
       // numberOfKillsText.text = killsText + "0";
     //   numberOfHealthLeft.text = healthText + "100";

    }

    // Update is called once per frame
    void Update () {

    }

    public void UpdateCurrentNumberOfKills(int currentKillsNumber)
    {
        numberOfKillsText.text = killsText + currentKillsNumber;
    }

    public void UpdateCurrentNumberOfHealth(int playerHealth)
    {
        numberOfHealthLeft.text = healthText + playerHealth;
    }

}
