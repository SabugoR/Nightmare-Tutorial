using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour {
    private Transform player;

    public int Health { get; internal set; }

    // Use this for initialization
    void Start () {
        Health = 50;
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        if (playerGameObject != null)
            player = playerGameObject.transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (Health > 0)
        {
            if (player != null)
            {
                GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(player.position);
                GetComponent<Animator>().SetBool("IsWalking", GetComponent<UnityEngine.AI.NavMeshAgent>().velocity.magnitude > 0);
            }
        }

    }

    public void decreaseHealth()
    {
        Health -= 10;
    }
}
