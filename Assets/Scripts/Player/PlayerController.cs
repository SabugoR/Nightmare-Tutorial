using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    ScoreManager scoreManager = null;
    float gunTimer = 0;
    float collisionTimer = 0;
    float timeBetweenShots = 0.3f;
    RectTransform healthRect;
    bool wasTriggered = false;
    [SerializeField] GameManager gManager;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject healthbar;
    [SerializeField] Joystick walkStick;
    [SerializeField] Joystick gunStick;
    private bool enemyContact = false;
    Collider currentEnemyCollider = null;
    public int Health { get; private set; }
    public bool IsRendered { get; internal set; }

    AudioSource[] sounds;//death, hurt, gunshot
    LineRenderer laserSight;
    // Use this for initialization
    void Start()
    {
        scoreManager = parent.GetComponent<ScoreManager>();
        laserSight = GetComponentInChildren<LineRenderer>();
        sounds = GetComponents<AudioSource>();
        Health = 100;
        healthRect = healthbar.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            if (!wasTriggered)
            {
                sounds[0].Play();
                wasTriggered = true;
                healthRect.sizeDelta = new Vector2(0, healthRect.sizeDelta.y);
                GetComponent<Animator>().SetTrigger("HasDied");
                Invoke("Deactivate", 3f);//maybe destroy?
            }
        }
        else
        {
            if (IsRendered)
            {
                healthRect.sizeDelta = new Vector2(Health*4, healthRect.sizeDelta.y);
                gunTimer += Time.deltaTime;
                collisionTimer += Time.deltaTime;
                var x = walkStick.Horizontal * Time.deltaTime * 5.0f;
                var z = walkStick.Vertical * Time.deltaTime * 5.0f;
                Vector3 movement = new Vector3(x, 0f, z);
                GetComponent<Rigidbody>().MovePosition(transform.position + movement);
                GetComponent<Animator>().SetBool("IsWalking", x != 0f || z != 0f);
                if (enemyContact && currentEnemyCollider != null)
                {
                    EnemyContact(currentEnemyCollider);
                }
                if (gunStick.Horizontal != 0 || gunStick.Vertical != 0)
                {
                    transform.LookAt(new Vector3(gunStick.Horizontal, 0f, gunStick.Vertical) + transform.position);
                }
               /* if ((Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)) && gunTimer >= timeBetweenShots)
                {
                    CheckRayCastHit();
                }*/
            }
        }

    }

    public void CheckRayCastHit()
    {
        if (IsRendered && gunTimer >= timeBetweenShots)
        {
            Ray shootRay = new Ray(); ;
            RaycastHit shootHit;
            shootRay.origin = laserSight.transform.position;//transform.position;
            shootRay.direction = transform.forward;
            Debug.DrawLine(shootRay.origin, shootRay.direction * 50, Color.blue, 2f);
            gunTimer = 0;
            GetComponentInChildren<ParticleSystem>().Play();
            sounds[2].Play();
            bool hit = Physics.Raycast(shootRay, out shootHit, Mathf.Infinity);
            if (hit)
            {
               // Debug.Log("Hit: " + shootHit.collider.name);
                gManager.HitEnemy(shootHit);
            }
        }
    }

    void EnemyContact(Collider col)
    {
       // Debug.Log("EnemyContact");
        if (collisionTimer >= timeBetweenShots)
        {
            sounds[1].Play();
            collisionTimer = 0;
            string enemyname = col.gameObject.name;
            if (enemyname.Contains("Bunny"))
                Health -= 10;
            if (enemyname.Contains("Bear"))
                Health -= 30;
            if (enemyname.Contains("Hell"))
                Health -= 50;

            
        }
            
    }

    void OnTriggerEnter(Collider col)
    {
       
        if (isEnemyName(col.gameObject.name))
        {
            enemyContact = true;
            currentEnemyCollider = col;
        }
    }

    private bool isEnemyName(string name)
    {
        return name.Contains("Bunny") || name.Contains("Bear") || name.Contains("elephant");
    }

    void OnTriggerExit(Collider col)
    {
        //Debug.Log("Exited trigger");
        if (isEnemyName(col.gameObject.name))
        {
            enemyContact= false;
            currentEnemyCollider = null;
        }
    }

    public void Deactivate()
    {
        parent.SetActive(false);
        scoreManager.SetHighScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
