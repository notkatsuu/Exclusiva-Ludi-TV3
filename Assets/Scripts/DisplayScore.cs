using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    void Start()
    {
        Text scoreText = GetComponent<Text>();
        scoreText.text = "" + ScoreManager.instance.score;
         ScoreSaver.instance.scores.Add(ScoreManager.instance.score);
        Cursor.visible = true;
    }
}

