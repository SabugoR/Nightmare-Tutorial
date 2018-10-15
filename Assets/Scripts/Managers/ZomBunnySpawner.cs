using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZomBunnySpawner : MonoBehaviour {

    bool hasDied = false;
    float timer = 0;
    public int numberOfAlreadySpawned { get; private set; }
    public int ListSize
    {
        get
        {
            return spawnedObjects.Count;
        }
        set
        {
        }
    }
       

    float timeBetweenSpawns = 3f;
    int numberOfTotalSpawns = 5;
    List<GameObject> spawnedObjects = new List<GameObject>();
    AudioSource[] sounds;
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject toSpawn;
    int count = 0;
	// Use this for initialization
	void Start () {
        GetComponentInChildren<ParticleSystem>().Play();
        sounds = GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        ListSize = spawnedObjects.Count;
        if(timer >= timeBetweenSpawns && numberOfAlreadySpawned < numberOfTotalSpawns)
        {
            timer = 0;
            numberOfAlreadySpawned++;
            spawnedObjects.Add(Instantiate(toSpawn, transform.position, transform.rotation));
            spawnedObjects.Last().name = "ZomBunny " + numberOfAlreadySpawned;
            spawnedObjects.Last().GetComponent<Collider>().isTrigger = true;
        }
    }

    public void Hit(RaycastHit castHit)
    {
        GameObject selected = spawnedObjects.Find(x => x.name.Equals(castHit.collider.name));
        if (selected != null)
        {
            BunnyController controller = selected.GetComponent<BunnyController>();
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
                Debug.Log("alreadyspawned: " + numberOfAlreadySpawned);
                Debug.Log("listsize: " + ListSize);
                spawnedObjects.Remove(selected);
                Debug.Log("listsize: " + ListSize);
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
