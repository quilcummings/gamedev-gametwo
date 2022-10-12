using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public GameObject monster;

    private Rigidbody2D rb;
    private GameObject player;
    
    [SerializeField] int speed = 10;
    
    void Start()
    {
        rb = monster.GetComponent<Rigidbody2D>();
        player = PlayerMovement.Instance.player;
    }

    void Update()
    {
        //for testing purposes
        animator.SetFloat("DistanceToPlayer", 10);
        
        Vector2 targ = new Vector2(player.transform.position.x, -3.03f);
        monster.transform.position = Vector2.MoveTowards(monster.transform.position, targ, speed * Time.deltaTime);

    }
}
