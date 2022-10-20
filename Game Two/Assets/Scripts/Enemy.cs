using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;
    
    public Animator animator;
    public GameObject monster;

    private bool attacking;

    private Rigidbody2D rb;
    private GameObject player;
    
    public bool dead = false;
    public bool start = false;
    
    [SerializeField] int speed = 10;

    public AudioSource aud;
    public AudioClip sound;
    private bool audPow = true;

    public float dist;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        rb = monster.GetComponent<Rigidbody2D>();
        player = PlayerMovement.Instance.player;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !start)
        {
            start = true;
            StartCoroutine(increaseSpeed());
        }

        dist = Vector2.Distance(PlayerMovement.Instance.transform.position, transform.position);

        if (dist < speed*3 && audPow && PlayerMovement.Instance.transform.position.x > 30)
        {
            aud.PlayOneShot(sound);
            audPow=false;
        }
        if (dist > speed*3+5)
        {
            audPow=true;
        }

        if (start)
        {
            if (animator.GetFloat("DistanceToPlayer") <= 5)
            {
                Attack();
            }
            else
            {
                dead = false;
                Vector2 targ = new Vector2(player.transform.position.x, -3.03f);
                monster.transform.position = Vector2.MoveTowards(monster.transform.position, targ, speed * Time.deltaTime);
            }
        }
       
    }

    public void Attack()
    {
        dead = true;
        PlayerMovement.Instance.rb.velocity = new Vector2(0, 0);
        
    }
    
    IEnumerator increaseSpeed()
    {
        while(true && speed<30)
        {
            speed++;
            yield return new WaitForSeconds(5);
        }
    }
}
