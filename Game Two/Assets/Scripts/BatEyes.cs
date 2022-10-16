using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEyes : MonoBehaviour
{
    public Animator animator;
    public Transform player;

    public static BatEyes Instance;
    public Rigidbody2D rb;

    public bool pow = true;
    public float mod = 0.5f;
    
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

        Ray2D eyes = new Ray2D(transform.position, player.position - transform.position);
        Debug.DrawRay(transform.position, player.position - transform.position);
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position - transform.position, 100f);
        if (hit && hit.collider.gameObject.tag == "Player")
        {
            animator.SetBool("CanWeSeePlayer", true);
        }
        else
        {
            animator.SetBool("CanWeSeePlayer", false);
        }
        if (WaitingForPlayer.Instance.start)
        {
            if (pow)
            {
                var time = Random.Range(1.0f, 4.0f);
                StartCoroutine(RandomMovement(time));
                pow = false;
            }
        }
        if (!WaitingForPlayer.Instance.start)
        {
            StopAllCoroutines();
            pow = true;
        }
    }

    IEnumerator RandomMovement(float time)
    {
        while (true)
        {
            float curTime = 0;
         
            Vector3 startPos = rb.transform.position;
            var position = new Vector3(Random.Range(player.position.x - 2.0f, player.position.x +3.0f), Random.Range(2.0f, 3.0f));
            
            while (curTime < time)
            {
                transform.position = Vector3.Lerp(startPos, position, (curTime / time));
                curTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
