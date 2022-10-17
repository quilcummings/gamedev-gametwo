using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        target = PlayerMovement.Instance.player.transform;
    }

    void Update()
    {
        transform.position = new Vector3(target.position.x, -1.53f, 0);
    }
}
