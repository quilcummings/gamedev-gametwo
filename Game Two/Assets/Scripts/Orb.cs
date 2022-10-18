using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : WorldManager
{
    public static Orb Instance;
    private int count = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rb = PlayerMovement.Instance.rb;
        target = PlayerMovement.Instance.player.transform;
        player = PlayerMovement.Instance.player;

        
    }

    void Update()
    {
        float dist = Vector2.Distance(PlayerMovement.Instance.transform.position, transform.position);
        if (dist <= 1)
        {
            PlayerMovement.Instance.score+=100;
            Destroy(gameObject);
        }
    }

    public override void AddCount()
    {
        count++;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    
}
