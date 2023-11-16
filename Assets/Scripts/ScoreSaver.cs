using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSaver : MonoBehaviour
{
    public List<int> scores = new List<int>();

    public static ScoreSaver instance;




    // Start is called before the first frame update    }

    // Update is called once per frame
    void Awake()
    {
        Cursor.visible = true;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // This object will persist across scenes
        }
        else
        {
            Destroy(gameObject); // If a ScoreManager already exists, destroy this one
        }
    }
}
