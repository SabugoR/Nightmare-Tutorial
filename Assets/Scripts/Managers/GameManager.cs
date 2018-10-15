using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField] ZomBunnySpawner bunnySpawner;
    [SerializeField] ZomBearSpawner bearSpawner;
    [SerializeField] HellephantSpawner elephantSpawner;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (bunnySpawner.numberOfAlreadySpawned != 0 || bearSpawner.numberOfAlreadySpawned != 0 || elephantSpawner.numberOfAlreadySpawned != 0) {
            if (bunnySpawner.ListSize == 0 && bearSpawner.ListSize == 0 && elephantSpawner.ListSize == 0)
            {
                SceneManager.LoadScene(3);
            }
        }
	}

    public void HitEnemy(RaycastHit castHit)
    {
        //Debug.Log("HitEnemy " + castHit.collider.name);
        if (castHit.collider.name.Contains("Bunny"))
            bunnySpawner.Hit(castHit);
        if (castHit.collider.name.Contains("Bear"))
            bearSpawner.Hit(castHit);
        if (castHit.collider.name.Contains("Hellephant"))
            elephantSpawner.Hit(castHit);
    }
}
