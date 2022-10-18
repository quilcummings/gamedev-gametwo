using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorldManager : MonoBehaviour
{
   
    public Transform target;
    public Rigidbody2D rb;
    public GameObject player;
    
    public abstract void AddCount();
    
    
}
