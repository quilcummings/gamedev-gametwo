using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorManager : MonoBehaviour
{
    public GameObject lampPF;

    private GameObject lamp;

    private GameObject player;

    void Start()
    {
        player = PlayerMovement.Instance.player;
        StartCoroutine(Decor());
    }

    IEnumerator Decor()
    {
        while (true)
        {
            lamp = GameObject.Instantiate(lampPF);
            float playerXPos = player.transform.position.x;
            float lampPos = playerXPos + 3.71f;
            
            lamp.transform.position = new Vector3(lampPos, -2.59f, 0);

            yield return new WaitForSeconds(10f);
        }
    }
}
