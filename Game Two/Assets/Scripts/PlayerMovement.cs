using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    
    public Animator animator;
    public Animator animator2;
    public Rigidbody2D rb;
    public GameObject player;

    public float runSpeed = 3f;

    public GameObject background;

    private float time;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        //Debug.Log(time);
        
        Debug.Log(time);
        
        if (Boost.Instance.check)
        {
            GetComponent<SpriteRenderer>().color = new Color(.52f, .82f, .97f);
            time += Time.deltaTime;
        }
        if (time > 5)
        {
            Boost.Instance.check = false;
            time = 0;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        }
        
        
        if (Input.GetKey(KeyCode.D) && animator.GetBool("isDashing") == false)
        {
            animator.SetBool("isMoving", true);
            
           if (!Boost.Instance.check)
            {
                Vector2 moveForce = new Vector2(.1f, 0);
                rb.AddForce(moveForce, ForceMode2D.Impulse);
                
                float maxSpeed = 10;
                Debug.Log("MAX: " + maxSpeed);
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            }
            else
            {
                Vector2 moveForce = new Vector2(1f, 0);
                rb.AddForce(moveForce, ForceMode2D.Impulse);
                
                float maxSpeed = 50;
                Debug.Log("MAX: " + maxSpeed);
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isMoving", false);
            rb.velocity = new Vector2(0, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("isDashing", true);
            
            if (!Boost.Instance.check)
            {
                Vector2 dashForce = new Vector2(20f, 0);
                rb.AddForce(dashForce, ForceMode2D.Impulse);
                
                float maxSpeed = 50;
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            }
            else
            {
                Vector2 dashForce = new Vector2(40f, 0);
                rb.AddForce(dashForce, ForceMode2D.Impulse);
                
                float maxSpeed = 100;
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("isDashing", false);
            rb.velocity = new Vector2(0, 0);
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
