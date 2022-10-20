using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI pressE;
    public TextMeshProUGUI batDia;
    public TextMeshProUGUI click;
    public TextMeshProUGUI score;
    public TextMeshProUGUI dist;
    public TextMeshProUGUI click2;
    
    public GameObject black;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        gameOver.text = "";
    }
    
    void Update()
    {
        //Debug.Log(Enemy.Instance.dead);

        score.text = "SCORE: " + PlayerMovement.Instance.score;

        if (BatEyes.Instance.displayText)
        {
            batDia.text = "Did you hear that? Sounds like trouble! Press shift to run and space to jump/accelerate.";
            click.text = "click to begin chase";
        }

        if (Enemy.Instance.start)
        {
            batDia.text = "";
            click.text = "";
            dist.text = "" + Enemy.Instance.dist;
        }
        if (Enemy.Instance.dead || PlayerMovement.Instance.player.transform.position.y >= 5 || PlayerMovement.Instance.player.transform.position.y <= -9)
        {
            black.SetActive(true);
            gameOver.text = "DEATH: INEVITABLE YET UNEXPECTED";
            click2.text = "click to reload";
            Enemy.Instance.dead = true;
        }
       
    }
}
