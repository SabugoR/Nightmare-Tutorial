using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZomBearSpawner : MonoBehaviour {

    float timer = 0;
    int numberOfAlreadySpawned = 0;
    float timeBetweenSpawns = 3f;
    int numberOfTotalSpawns = 5;
    List<GameObject> spawnedObjects = new List<GameObject>();

    [SerializeField] GameObject toSpawn;
    // Use this for initialization
    void Start()
    {
        GetComponentInChildren<ParticleSystem>().Play();
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
            spawnedObjects.Last().name = "ZomBear " + numberOfAlreadySpawned;
        }
    }

    public void Hit(RaycastHit castHit)
    {
        GameObject selected = spawnedObjects.Find(x => x.name.Equals(castHit.collider.name));
        Debug.Log("new" + selected + "   " + selected.name);
        BearController controller = selected.GetComponent("BearController") as BearController;
        controller.decreaseHealth();
        ParticleSystem particles = selected.GetComponentInChildren<ParticleSystem>();
        particles.transform.position = castHit.point;
        particles.Play();
        if (controller.Health <= 0)
        {
            selected.GetComponent<Animator>().SetTrigger("HasDied");
            selected.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            StartCoroutine("Deactivate", selected);
        }

        // throw new NotImplementedException();
    }
    public IEnumerator Deactivate(GameObject selected)
    {
        yield return new WaitForSeconds(2f);
        selected.SetActive(false);
    }

}
