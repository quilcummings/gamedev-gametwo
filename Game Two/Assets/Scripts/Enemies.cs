using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    //public static Enemies Instance;
    //public bool hit = false;

    void Awake()
    {
        //Instance = this;
    }

    public abstract void Attack();
    
}
