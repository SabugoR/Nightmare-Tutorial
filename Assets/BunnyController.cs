using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour {
    private Transform player;
    // Use this for initialization
    void Start () {
		player  = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(player.position);
        GetComponent<Animator>().SetBool("IsWalking", GetComponent<UnityEngine.AI.NavMeshAgent>().velocity.magnitude > 0 );

    }
}
