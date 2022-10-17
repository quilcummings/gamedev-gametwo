using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorManager : WorldManager
{
    public GameObject lampPF;
    public GameObject fencePF;

    private GameObject lamp;
    private GameObject fence;
    private GameObject fence2;

    private int count = 0;

    //private GameObject player;

    void Start()
    {
        player = PlayerMovement.Instance.player;
        StartCoroutine(Decor());
    }

    IEnumerator Decor()
    {
        while (true)
        {
            lamp = GameObject.Instantiate(lampPF);
            fence = GameObject.Instantiate(fencePF);

            float playerXPos = player.transform.position.x;

            float fencePos = playerXPos + Random.Range(10, 25);

            float lampPos = fencePos + 3.71f;
            
            lamp.transform.position = new Vector3(lampPos, -2.59f, 0);
            fence.transform.position = new Vector3(fencePos, -4.16f, 0);

            if (count%5==0)
            {
                fence2 = GameObject.Instantiate(fencePF);
                fence2.transform.position = new Vector3(lampPos+3.96f, -4.16f, 0);
            }

            if (player.transform.position.x > lamp.transform.position.x + 10)
            {
                Destroy(lamp);
            }

            if (player.transform.position.x > fence.transform.position.x + 10)
            {
                Destroy(fence);
            }

            //count++;
            AddCount();
            yield return new WaitForSeconds(10f);
        }
    }

    public override void AddCount()
    {
        count++;
    }
}
