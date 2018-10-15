using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class StartSpawning : MonoBehaviour {
    [SerializeField] GameObject toSpawn;
    TrackableBehaviour trackbleBehaviour;
    bool alreadySpawned = false;
	// Use this for initialization
	void Start () {
        trackbleBehaviour = GetComponent<TrackableBehaviour>();
    }
	
	// Update is called once per frame
	void Update () {

       if (!alreadySpawned && trackbleBehaviour.CurrentStatus == TrackableBehaviour.Status.TRACKED)
        {
            if (toSpawn.tag != "Player")
            {
                toSpawn.SetActive(true);
                alreadySpawned = true;
            }
            else
            {
                Renderer[] array = toSpawn.GetComponentsInChildren<Renderer>();
                foreach (Renderer rend in array)
                {
                    rend.enabled = true;
                }
                toSpawn.GetComponent<PlayerController>().IsRendered = true;
            }
           
       } // 


    }
}
