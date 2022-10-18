using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    public SaveObject so;

    void Update()
    {   
       
        if (PlayerMovement.Instance.score > so.score)
        {
            so.score = PlayerMovement.Instance.score;
            GameHandler.Save(so);
        }
        else
        {
            so.score = GameHandler.Load().score;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            so = GameHandler.Load();
            Debug.Log(GameHandler.Load().score);
            PlayerMovement.Instance.score = GameHandler.Load().score;
        }
    }
}
