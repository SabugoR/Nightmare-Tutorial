﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HellephantSpawner : MonoBehaviour {

    float timer = 0;
    int numberOfAlreadySpawned = 0;
    float timeBetweenSpawns = 1f;
    int numberOfTotalSpawns = 1;
    List<GameObject> spawnedObjects = new List<GameObject>();

    [SerializeField] GameObject toSpawn;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenSpawns && numberOfAlreadySpawned < numberOfTotalSpawns)
        {
            timer = 0;
            numberOfAlreadySpawned++;
            spawnedObjects.Add(Instantiate(toSpawn, transform.position, transform.rotation));
            spawnedObjects.Last().name = "Hellephant " + numberOfAlreadySpawned;
        }
    }

    public void Hit(string name)
    {
        GameObject selected = spawnedObjects.Find(x => x.name.Equals(name));
        HellephantController controller = selected.GetComponent<HellephantController>();
        controller.decreaseHealth();
        if (controller.Health <= 0)
        {
            selected.GetComponent<Animator>().SetTrigger("HasDied");
            selected.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            Destroy(selected, 2f);
        }
    }
}