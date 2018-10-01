using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;
        Vector3 movement = new Vector3(x, 0f, z);
        GetComponent<Rigidbody>().MovePosition(transform.position + movement);
        Vector3 worldpos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 7));
        transform.LookAt(new Vector3(worldpos.x, transform.position.y, worldpos.z));
        GetComponent<Animator>().SetBool("IsWalking", x != 0f || z != 0f);
        if (Input.GetButton("Fire1"))
        {
            // ... shoot the gun.
            CheckRayCastHit();
        }

    }

    private void CheckRayCastHit()
    {
        Ray shootRay = new Ray(); ;
        RaycastHit shootHit;
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        if (Physics.Raycast(shootRay, out shootHit, Mathf.Infinity))
        {
            // Try and find an EnemyHealth script on the gameobject hit.
            //EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            Debug.Log("Hit:" + shootHit.collider.name);

        }
    }
}
