using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    
    public Animator animator;
    public Rigidbody2D rb;
    public GameObject player;

    public float runSpeed = 3f;

    public GameObject background;

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
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isMoving", true);
            
            Vector2 moveForce = new Vector2(.05f, 0);
            rb.AddForce(moveForce, ForceMode2D.Impulse);

            float maxSpeed = 10;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isMoving", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("isDashing", true);
            
            Vector2 dashForce = new Vector2(1f, 0);
            rb.AddForce(dashForce, ForceMode2D.Impulse);
            
            float maxSpeed = 20;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("isDashing", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 upForce = new Vector2(3, 10);
            rb.AddForce(upForce, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isJumping", false);
        }
    }
}
