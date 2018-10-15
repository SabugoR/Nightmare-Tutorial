using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZomBearSpawner : MonoBehaviour {

    bool hasDied = false;
    float timer = 0;
    int numberOfAlreadySpawned = 0;
    float timeBetweenSpawns = 5f;
    int numberOfTotalSpawns = 5;
    List<GameObject> spawnedObjects = new List<GameObject>();

    [SerializeField] GameObject HUD;
    [SerializeField] GameObject toSpawn;
    AudioSource[] sounds;
    // Use this for initialization
    void Start()
    {
        GetComponentInChildren<ParticleSystem>().Play();
        sounds = GetComponents<AudioSource>();
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
            spawnedObjects.Last().GetComponent<Collider>().isTrigger = true;
        }
    }

    public void Hit(RaycastHit castHit)
    {
        GameObject selected = spawnedObjects.Find(x => x.name.Equals(castHit.collider.name));
        if (selected != null)
        {
            Debug.Log("new" + selected + "   " + selected.name);
            BearController controller = selected.GetComponent("BearController") as BearController;
            controller.decreaseHealth();
            ParticleSystem particles = selected.GetComponentInChildren<ParticleSystem>();
            particles.transform.position = castHit.point;
            particles.Play();
            sounds[0].Play();
            if (controller.Health <= 0)
            {
                HUD.GetComponent<HUDManager>().UpdateCurrentNumberOfKills(50);
                sounds[1].Play();
                selected.GetComponent<Animator>().SetTrigger("HasDied");
                selected.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                HUD.GetComponent<HUDManager>().UpdateCurrentNumberOfKills(100);
                spawnedObjects.Remove(selected);
                StartCoroutine("Deactivate", selected);
            }
        }
        // throw new NotImplementedException();
    }
    public IEnumerator Deactivate(GameObject selected)
    {
        yield return new WaitForSeconds(2f);
        selected.SetActive(false);
    }

}
