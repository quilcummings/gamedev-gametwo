using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager Instance;
    private Rigidbody2D rb;

    private Transform target;
    
    private int bgCount = 2;
    private int match = 2;
    public float xPos;
    
    public GameObject ground;
    public GameObject ground2;
    //public GameObject backgroundLayer;
    
    private GameObject gr;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        rb = PlayerMovement.Instance.rb;
        target = PlayerMovement.Instance.player.transform;
        //StartCoroutine(makeBG());
    }
    
    void Update()
    {
        if (rb.position.x > xPos - 10 && match != bgCount)
        {
            match++;
        }

        if (bgCount % 5 == 0)
        {
            xPos = 18.37f * bgCount;
            GameObject gr = Instantiate(ground2, new Vector3(xPos, 5, 0), Quaternion.identity);
            ground2.transform.parent = gr.transform.parent;
            bgCount++;
        }
        else if (bgCount == match)
        {
            xPos = 18.37f * bgCount;
            GameObject gr = Instantiate(ground, new Vector3(xPos, 0, 0), Quaternion.identity);
            ground.transform.parent = gr.transform.parent;
            bgCount++;
        }
    }

    IEnumerator makeBG()
    {
        if (rb.position.x > xPos - 10 && match != bgCount)
        {
            match++;
        }
        if (bgCount == match)
        {
            xPos = 18.37f * bgCount;
            gr = Instantiate(ground, new Vector3(xPos, 0, 0), Quaternion.identity);
            ground.transform.parent = gr.transform.parent;
            bgCount++;
        }
        if (rb.position.x > xPos * 2)
        {
            Destroy(gr);
        }
        yield return new WaitForSeconds(.1f);
    }
}
