using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Enemies
{
    public static Enemy Instance;
    
    public Animator animator;
    public GameObject monster;

    private bool attacking;

    private Rigidbody2D rb;
    private GameObject player;
    
    [SerializeField] int speed = 10;

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
        if (animator.GetFloat("DistanceToPlayer") <= 5)
        {
            Attack();
        }
        else
        {
            Vector2 targ = new Vector2(player.transform.position.x, -3.03f);
            monster.transform.position = Vector2.MoveTowards(monster.transform.position, targ, speed * Time.deltaTime);
        }
    }

    public override void Attack()
    {
        // stop to attack
        // stun player (pause movement)
    }
}
