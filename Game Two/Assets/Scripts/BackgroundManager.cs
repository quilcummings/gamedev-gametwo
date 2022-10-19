using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : WorldManager
{
    public static BackgroundManager Instance;

    private int bgCount = 2;
    private int match = 2;
    public float xPos;
    
    public GameObject ground;
    public GameObject ground2;
    public GameObject platform;
    public GameObject groundWithLamp;
    //public GameObject block;

    private GameObject gr;
    private GameObject plat;
    //private GameObject blocked;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        rb = PlayerMovement.Instance.rb;
        target = PlayerMovement.Instance.player.transform;
    }
    
    void Update()
    {
        if (rb.position.x > xPos - 10 && match != bgCount)
        {
            match++;
        }

        if (bgCount % 4 == 0)
        {
            xPos = 18.37f * bgCount;
            
            GameObject gr = Instantiate(ground, new Vector3(xPos, 0, 0), Quaternion.identity);
            ground.transform.parent = gr.transform.parent;
            
            GameObject plat = Instantiate(platform, new Vector3(xPos, 0, 0), Quaternion.identity);
            platform.transform.parent = plat.transform.parent;
            //bgCount++;
            AddCount();
        }
        
        //if (bgCount % 7 == 0)
        {
          //  xPos = 18.37f * bgCount;
           // GameObject blocked = Instantiate(block, new Vector3(xPos, 0, 0), Quaternion.identity);
            //blocked.transform.parent = block.transform.parent;
           
            //AddCount();
        }
        
        if (bgCount % 5 == 0)
        {
            xPos = 18.37f * bgCount;
            GameObject gr = Instantiate(ground2, new Vector3(xPos, 5, 0), Quaternion.identity);
            ground2.transform.parent = gr.transform.parent;
            //bgCount++;
            AddCount();
        }
        else if (bgCount == match)
        {
            xPos = 18.37f * bgCount;
            if (bgCount % 9 == 0)
            {
                GameObject gr = Instantiate(groundWithLamp, new Vector3(xPos, 0, 0), Quaternion.identity);
                groundWithLamp.transform.parent = gr.transform.parent;
            }
            else
            {
                GameObject gr = Instantiate(ground, new Vector3(xPos, 0, 0), Quaternion.identity);
                ground.transform.parent = gr.transform.parent;
            }
            
            AddCount();
        }
    }
    
    public override void AddCount()
    {
        bgCount++;
    }
}
