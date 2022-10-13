using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject rock1PF;
    public GameObject rock2PF;
    public GameObject rock3PF;

    private GameObject rock1;
    private GameObject rock2;
    private GameObject rock3;

    private GameObject player;
    
    void Start()
    {
        player = PlayerMovement.Instance.player;
        StartCoroutine(DeployRock());
    }
    
    IEnumerator DeployRock()
    {
        while (true)
        {   
            rock1 = GameObject.Instantiate(rock1PF);
            rock2 = GameObject.Instantiate(rock2PF);
            rock3 = GameObject.Instantiate(rock3PF);

            float playerXPos = player.transform.position.x;

            float rock1Pos = playerXPos + Random.Range(10, 25);
            float rock2Pos = playerXPos + Random.Range(10, 25);
            if (rock2Pos >= rock1Pos - 5 && rock2Pos <= rock1Pos + 5)
            {
                rock2Pos += 5;
            }
            float rock3Pos = playerXPos + Random.Range(50, 100);
            if (rock3Pos >= rock2Pos - 5 && rock3Pos <= rock2Pos + 5)
            {
                rock3Pos += 5;
            }

            rock1.transform.position = new Vector3(rock1Pos, -4.6f, 0);
            rock2.transform.position = new Vector3(rock2Pos, -4.5f, 0);
            rock3.transform.position = new Vector3(rock3Pos, -4.5f, 0);

            if (player.transform.position.x > rock1.transform.position.x + 10)
            {
                Destroy(rock1);
            }
            if (player.transform.position.x > rock2.transform.position.x + 10)
            {
                Destroy(rock2);
            }
            if (player.transform.position.x > rock3.transform.position.x + 10)
            {
                Destroy(rock3);
            }
            yield return new WaitForSeconds(5f);
        }
    }
}
