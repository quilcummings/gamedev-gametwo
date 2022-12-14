using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : WorldManager
{
    public static PlayerMovement Instance;
    
    public Animator animator;
    public Animator animator2;
    //public Rigidbody2D rb;
    //public GameObject player;

    public float runSpeed = 3f;

    public GameObject background;

    private float time;
    public float score;

    public bool check;

    private bool audPow=true;

    public AudioSource aud;
    public AudioClip sound;
    public float maxSpeed;



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
    
        

        if (Enemy.Instance.start && audPow)
        {
            StartCoroutine(AddScore());
            audPow=false;
        }
        if (Input.GetMouseButtonDown(0) && Enemy.Instance.dead)
        {
            Enemy.Instance.dead = false;
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene("Load Screen", LoadSceneMode.Single);
        }
        
        if (check)
        {
            GetComponent<SpriteRenderer>().color = new Color(.52f, .82f, .97f);
            time += Time.deltaTime;
            AddCount();
        }
        if (time > 5)
        {
            check = false;
            //once = true;
            time = 0;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        }

        if (Enemy.Instance.start)
        {
            if (Input.GetKey(KeyCode.D) && animator.GetBool("isDashing") == false)
            {
                animator.SetBool("isMoving", true);
            
                if (!check)
                {
                    Vector2 moveForce = new Vector2(.2f, 0);
                    rb.AddForce(moveForce, ForceMode2D.Impulse);
                
                    maxSpeed = 20;
                    rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
                }
                else
                {
                    Vector2 moveForce = new Vector2(1f, 0);
                    rb.AddForce(moveForce, ForceMode2D.Impulse);
                
                    maxSpeed = 50;
                    rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
                }
            } 
            if (Input.GetKey(KeyCode.A) && animator.GetBool("isDashing") == false)
            {
                animator.SetBool("isMoving", true);
            
                if (!check)
                {
                    Vector2 moveForce = new Vector2(-.2f, 0);
                    rb.AddForce(moveForce, ForceMode2D.Impulse);
                
                    maxSpeed = 20;
                    rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
                }
                else
                {
                    Vector2 moveForce = new Vector2(-1f, 0);
                    rb.AddForce(moveForce, ForceMode2D.Impulse);
                
                    maxSpeed = 50;
                    rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
                }
            } 
            if (Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("isMoving", false);
                rb.velocity = new Vector2(.2f, 0);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                animator.SetBool("isMoving", false);
                rb.velocity = new Vector2(-.2f, 0);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                animator.SetBool("isDashing", true);
            
                if (!check)
                {
                    Vector2 dashForce = new Vector2(30f, 0);
                    rb.AddForce(dashForce, ForceMode2D.Impulse);
                
                    maxSpeed = 30;
                    rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
                }
                else
                {
                    Vector2 dashForce = new Vector2(40f, 0);
                    rb.AddForce(dashForce, ForceMode2D.Impulse);
                
                    maxSpeed = 50;
                    rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                animator.SetBool("isDashing", false);
                rb.velocity = new Vector2(.2f, 0);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(rb.velocity);
                if (!check)
                {
                    Vector2 upForce = new Vector2(3, 6);
                    rb.AddForce(upForce, ForceMode2D.Impulse);
                    animator.SetBool("isJumping", true);

                    maxSpeed = 30;
                    rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
                }
                else
                {
                    Vector2 upForce = new Vector2(5, 10);
                    rb.AddForce(upForce, ForceMode2D.Impulse);
                    animator.SetBool("isJumping", true);

                    maxSpeed = 50;
                    rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("isJumping", false);
            }
        }
    }

    public override void AddCount()
    {
        score+=100;
    }

    IEnumerator AddScore()
    {
        while(true)
        {
            score++;
            yield return new WaitForSeconds(.5f);
        }
    }
  
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "orb")
        {
            Vector2 orbForce = new Vector2(5, 0);
            rb.AddForce(orbForce, ForceMode2D.Impulse);
        }
    }
    
}
