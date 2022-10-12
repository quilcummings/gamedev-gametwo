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
    
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerMovement.Instance.player;
        StartCoroutine(DeployRock());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator DeployRock()
    {
        while (true)
        {   
            rock1 = GameObject.Instantiate(rock1PF);
            rock1.transform.position = new Vector3(player.transform.position.x + Random.Range(50, 100), -4.5f, 0);

            if (player.transform.position.x > rock1.transform.position.x + 10)
            {
                Destroy(rock1);
            }
            yield return new WaitForSeconds(5f);
        }
    }
}
