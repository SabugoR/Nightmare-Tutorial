using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float timer = 0;
    float timeBetweenShots = 0.3f;

    [SerializeField] GameManager gManager;
    [SerializeField] GameObject parent;
    public int Health { get; private set; }

    // Use this for initialization
    void Start()
    {
        Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            GetComponent<Animator>().SetTrigger("HasDied");
            Invoke("Deactivate", 2f);//maybe destroy?
        }
        else
        {
            timer += Time.deltaTime;
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;
            Vector3 movement = new Vector3(x, 0f, z);
            GetComponent<Rigidbody>().MovePosition(transform.position + movement);
            Vector3 worldpos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 7));
            transform.LookAt(new Vector3(worldpos.x, transform.position.y, worldpos.z));
            GetComponent<Animator>().SetBool("IsWalking", x != 0f || z != 0f);
            if (Input.GetButton("Fire1") && timer >= timeBetweenShots)
            {
                timer = 0;
                GetComponentInChildren<ParticleSystem>().Play();
                CheckRayCastHit();
            }

        }

    }

    private void CheckRayCastHit()
    {
        Ray shootRay = new Ray(); ;
        RaycastHit shootHit;
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, Mathf.Infinity))
        {
            Debug.Log("Hit: " + shootHit.collider.name);
            gManager.HitEnemy(shootHit);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        string enemyname = col.gameObject.name;
        if (enemyname.Contains("Bunny"))
            Health -= 10;
        if (enemyname.Contains("Bear"))
            Health -= 30;
        if (enemyname.Contains("Hell"))
            Health -= 50;
            
    }

    public void Deactivate()
    {
        parent.SetActive(false);
    }
}
