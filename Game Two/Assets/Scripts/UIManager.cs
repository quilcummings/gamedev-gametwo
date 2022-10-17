using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI gameOver;
    public GameObject black;
    void Start()
    {
        gameOver.text = "";
    }
    
    void Update()
    {
        //Debug.Log(Enemy.Instance.dead);
        if (Enemy.Instance.dead)
        {
            black.SetActive(true);
            gameOver.text = "DEATH: INEVITABLE YET UNEXPECTED";
        }
        else
        {
            gameOver.text = "";
        }
    }
}
