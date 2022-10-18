using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighScore : MonoBehaviour
{
    public TextMeshProUGUI hs;
    void Update()
    {
        hs.text = "HIGH SCORE: " + GameHandler.Load().score;
    }
}
