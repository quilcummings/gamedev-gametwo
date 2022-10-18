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
    void Start()
    {
        rb = PlayerMovement.Instance.rb;
        target = PlayerMovement.Instance.player.transform;
        player = PlayerMovement.Instance.player;

        StartCoroutine(DiamondSpawn());
    }

    void Update()
    {
        
    }
    IEnumerator DiamondSpawn()
    {
        while (true)
        {
            if (count <= 1)
            {
                diamond = GameObject.Instantiate(diamondPF);
                AddCount();
            }
            

            float playerXPos = player.transform.position.x;
            float diamondPos = playerXPos + Random.Range(10, 25);
            
            diamond.transform.position = new Vector3(diamondPos+3.96f, -4.16f, 0);
            
            Debug.Log("Player: " + player.transform.position.x);
            Debug.Log("Diamond: " + diamond.transform.position.x);
            if (player.transform.position.x > diamond.transform.position.x - 20)
            {
                Destroy(diamond);
                count--;
            }

            yield return new WaitForSeconds(5f);
        }
    }
    
    public override void AddCount()
    {
        count++;
    }
    
}
