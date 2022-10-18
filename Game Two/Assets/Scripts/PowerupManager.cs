using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerupManager : WorldManager
{

    private int count;

    public GameObject diamondPF;
    private GameObject diamond;

    public GameObject orbPF;
    private GameObject orb;
    private GameObject orb2;
    private GameObject orb3;

    private bool check = true;

    void Start()
    {
        rb = PlayerMovement.Instance.rb;
        target = PlayerMovement.Instance.player.transform;
        player = PlayerMovement.Instance.player;

    }

    void Update()
    {
       if (Enemy.Instance.start && check)
       {
            StartCoroutine(DiamondSpawn());
            StartCoroutine(OrbSpawn());
            check = false;
       }
    }
    IEnumerator DiamondSpawn()
    {
        while (true)
        {
            
            diamond = GameObject.Instantiate(diamondPF);
            AddCount();
            
            float playerXPos = rb.transform.position.x;
            float diamondPos = playerXPos + Random.Range(10, 25);
            
            diamond.transform.position = new Vector3(diamondPos+3.96f, -4.16f, 0);

            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator OrbSpawn()
    {
        while (true)
        {
            
            orb = GameObject.Instantiate(orbPF);
            orb2 = GameObject.Instantiate(orbPF);
            orb3 = GameObject.Instantiate(orbPF);
        
            
            float playerXPos = rb.transform.position.x;
            float orbPos = playerXPos + Random.Range(10, 25);

            float orbYPos = Random.Range(-4.16f, 6f);
            
            orb.transform.position = new Vector3(orbPos+3.96f, orbYPos, 0);
            orb2.transform.position = new Vector3(orbPos+6.96f, orbYPos, 0);
            orb3.transform.position = new Vector3(orbPos+9.96f, orbYPos, 0);

            yield return new WaitForSeconds(2f);
        }
    }

    
    public override void AddCount()
    {
        count++;
    }

   
}
