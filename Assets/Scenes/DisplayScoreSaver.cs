using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScoreSaver : MonoBehaviour
{
    public Text scoreArrayText;

    void Start()
    {

        foreach (int score in ScoreSaver.instance.scores)
        {
            scoreArrayText.text += "<color=#33FF33>" + score.ToString() + "</color> PP \n";
        }

    }
}
