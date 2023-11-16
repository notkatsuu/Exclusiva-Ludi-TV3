using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameLoadNSave : MonoBehaviour




{


    public Text saveGame;

    public InputField input;

    // Start is called before the first frame update
    void Start()

    {

        saveGame.text = StatsManager.instance.GetStatsAsJson();


        input.onEndEdit.AddListener(OnInputValueChanged);
    }

    // Update is called once per frame




    void OnInputValueChanged(string newValue)
    {
        // Call SetStatsFromJson with the new value
        StatsManager.instance.SetStatsFromJson(newValue);
    }




   
}


