using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] ZomBunnySpawner bunnySpawner;
    [SerializeField] ZomBearSpawner bearSpawner;
    [SerializeField] HellephantSpawner elephantSpawner;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HitEnemy(RaycastHit castHit)
    {
        Debug.Log("HitEnemy " + castHit.collider.name);
        if (castHit.collider.name.Contains("Bunny"))
            bunnySpawner.Hit(castHit);
        if (castHit.collider.name.Contains("Bear"))
            bearSpawner.Hit(castHit);
        if (castHit.collider.name.Contains("Hellephant"))
            elephantSpawner.Hit(castHit);
    }
}
