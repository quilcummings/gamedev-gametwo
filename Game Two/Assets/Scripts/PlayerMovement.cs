using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    
    //public Transform transfo;
    public Animator animator;
    public Rigidbody2D rb;

    private float startTime;
    private float journeyLength;

    private Vector3 destination;
    public float runSpeed = 3f;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            destination = new Vector3(rb.position.x + 5, 0, 0);
            animator.SetBool("isMoving", true);
            StartCoroutine(Move(4f));
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isMoving", false);
            StopAllCoroutines();
        }

        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("isDashing", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("isDashing", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isJumping", false);
        }
    }

    IEnumerator Move(float time)
    {
        float timeElap = 0;
        while (timeElap < time)
        {
            rb.position = Vector2.Lerp(rb.position, destination, timeElap / time);
            timeElap += Time.deltaTime;
            yield return null;
        }
    }
}
