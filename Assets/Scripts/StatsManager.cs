using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public int extraSize = 1;

    public bool betterUI = true;

    public int speedMultiplier = 10;

    public int focusMultiplier = 1;

    public float flashIntensity = 0.5f;


    public int coins = 100;
    public bool upgradeAvailable;

    public static StatsManager instance;





    void Awake()
    {

        if (coins>10)upgradeAvailable = false;
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
    // Start is called before the first frame update

     public string GetStatsAsJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void SetStatsFromJson(string json)
{
    JsonUtility.FromJsonOverwrite(json, this);
}





}


