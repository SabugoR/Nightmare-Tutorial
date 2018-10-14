using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantController : MonoBehaviour {

    private GameObject playerObject;
    PlayerController playerController;
    public int Health { get; internal set; }
    // Use this for initialization
    void Start()
    {
        Health = 200;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerController = playerObject.GetComponent<PlayerController>();
        Animator anim = GetComponent<Animator>();
        anim.SetBool("IsWalking", false);
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.AI.NavMeshAgent navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Animator anim = GetComponent<Animator>();
        if (playerObject != null && playerObject.transform != null)
        {
            if (Health > 0 && playerController.IsRendered && playerController.Health > 0)
        {
			
            navAgent.SetDestination(playerObject.transform.position);
            anim.SetBool("IsWalking", GetComponent<UnityEngine.AI.NavMeshAgent>().velocity.magnitude > 0);
			}
        }
        else
        {
                navAgent.enabled = false;
                anim.SetBool("IsWalking", false);
            
        }

    }

    public void decreaseHealth()
    {
        Health -= 10;
    }
}
