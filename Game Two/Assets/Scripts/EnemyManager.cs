using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : WorldManager
{
    public GameObject batPF;
    private GameObject bat;
    
    void Start()
    {
        rb = PlayerMovement.Instance.rb;
        target = PlayerMovement.Instance.player.transform;
        StartCoroutine(CreateEnemies());
    }

    IEnumerator CreateEnemies()
    {
        for (int i = 0; i < 5; i++)
        {
            bat = GameObject.Instantiate(batPF);
            
        }
        yield return new WaitForSeconds(5);
    }
    
}
