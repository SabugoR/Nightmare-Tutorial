using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantController : MonoBehaviour {

    private GameObject playerObject;

    public int Health { get; internal set; }
    // Use this for initialization
    void Start()
    {
        Health = 200;
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.AI.NavMeshAgent navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Animator anim = GetComponent<Animator>();
        if (Health > 0 && playerObject.GetComponent<PlayerController>().Health > 0)
        {
			if(playerObject.transform != null){
            navAgent.SetDestination(playerObject.transform.position);
            anim.SetBool("IsWalking", GetComponent<UnityEngine.AI.NavMeshAgent>().velocity.magnitude > 0);
			}
        }
        else
        {
            if (true)//transform.parent.gameObject.activeSelf)
            {
                navAgent.enabled = false;
                anim.SetBool("IsWalking", false);
            }
        }

    }

    public void decreaseHealth()
    {
        Health -= 10;
    }
}
