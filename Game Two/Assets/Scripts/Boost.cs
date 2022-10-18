using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public static Boost Instance;
    private float time = 0;

    public GameObject diamondPF;

    public bool check;
    void Awake()
    {
        Instance = this;
    }
    
    void Update()
    {
        //Debug.Log("Check: " + Boost.Instance.check);
        float distance = Vector2.Distance(PlayerMovement.Instance.transform.position, transform.position);

        if (distance <= 1)
        {
            UIManager.Instance.pressE.text = "hold E to boost";

            if (Input.GetKey(KeyCode.E))
            {
                time += Time.deltaTime;
                if (time >= 2.5)
                {
                    UIManager.Instance.pressE.text = "";
                    check = true;
                }
            }
        }
        else
        {
            UIManager.Instance.pressE.text = "";
            time = 0;
        }
    }

}
