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
        if (!alreadySpawned && trackbleBehaviour.CurrentStatus == TrackableBehaviour.Status.TRACKED) {
            toSpawn.transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            toSpawn.SetActive(true);
            alreadySpawned = true;
        }


    }
}
