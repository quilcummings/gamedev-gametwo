using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager Instance;
    private Rigidbody2D rb;

    private int bgCount = 2;
    private int match = 2;
    public float xPos;
    
    public GameObject background;
    public GameObject ground;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        rb = PlayerMovement.Instance.rb;
    }
    
    void Update()
    {
        if (rb.position.x > xPos - 10 && match != bgCount)
        {
            match++;
        }
        if (bgCount == match)
        {
            xPos = 18.37f * bgCount;
            GameObject bg = Instantiate(background, new Vector3(xPos, -1f, 0), Quaternion.identity);
            GameObject gr = Instantiate(ground, new Vector3(xPos, 0, 0), Quaternion.identity);
            ground.transform.parent = gr.transform.parent;
            bgCount++;
            
        }
    }
}
