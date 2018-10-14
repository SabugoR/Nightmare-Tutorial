using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour {
    private Transform player;
    GameObject playerGameObject;
    PlayerController playerController;
    public int Health { get; internal set; }

    // Use this for initialization
    void Start () {
        Health = 50;
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        Animator anim = GetComponent<Animator>();
        anim.SetBool("IsWalking", false);
        if (playerGameObject != null)
        {
            player = playerGameObject.transform;
            playerController = playerGameObject.GetComponent<PlayerController>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Health > 0)
        {
           if (player != null && playerController.IsRendered && playerController.Health > 0)
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
