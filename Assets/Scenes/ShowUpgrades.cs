using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUpgrades : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject upgrade;
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {

        if (StatsManager.instance.upgradeAvailable==true) upgrade.SetActive(true);
        else upgrade.SetActive(false);
        
    }
}
