using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeManager : MonoBehaviour
{


    public Text extraSizeText;
    public int extraSizePrice = 10;

    public Text betterUIText;

    public int betterUIPrice = 100;
    public Text speedMultiplierText;
    public int speedMultiplierPrice = 10;
    public Text focusMultiplierText;
    public int focusMultiplierPrice = 10;

    public Text coinsCollected;




    void Update()
    {
        // Start is called before the first frame update
        extraSizeText.text = StatsManager.instance.extraSize.ToString();
        betterUIText.text = StatsManager.instance.betterUI.ToString();
        speedMultiplierText.text = StatsManager.instance.speedMultiplier.ToString();
        focusMultiplierText.text = StatsManager.instance.focusMultiplier.ToString();

        coinsCollected.text = StatsManager.instance.coins.ToString();

    }

    public void increaseSize()
    {
        if (StatsManager.instance.coins >= extraSizePrice)
        {
            if (StatsManager.instance.extraSize < 15)
            {
                StatsManager.instance.extraSize += 1;
                StatsManager.instance.coins -= extraSizePrice;
            }
        }
    }

    public void EnhanceUI()
    {
        if (StatsManager.instance.coins >= betterUIPrice && StatsManager.instance.betterUI != true)
        {
            StatsManager.instance.betterUI = true;
            StatsManager.instance.coins -= betterUIPrice;
        }
    }

    public void increaseSpeed()
    {
        if (StatsManager.instance.coins >= speedMultiplierPrice)
        {
            if (StatsManager.instance.speedMultiplier < 15)
            {
                StatsManager.instance.speedMultiplier += 1;
                StatsManager.instance.coins -= speedMultiplierPrice;
            }
        }
    }

    public void increaseFocus()
    {
        if (StatsManager.instance.coins >= focusMultiplierPrice)
        {
            if (StatsManager.instance.focusMultiplier < 8)
            {
                StatsManager.instance.focusMultiplier += 1;
                StatsManager.instance.coins -= focusMultiplierPrice;
            }
        }
    }

    public void decreaseSize()
    {
        if (StatsManager.instance.extraSize > 0)
        {
            StatsManager.instance.extraSize -= 1;
            StatsManager.instance.coins += extraSizePrice;
        }
    }

    public void DehanceUI()
    {
        if (StatsManager.instance.betterUI == true)
        {
            StatsManager.instance.betterUI = false;
            StatsManager.instance.coins += betterUIPrice;
        }
    }


    public void decreaseSpeed()
    {
        if (StatsManager.instance.speedMultiplier > 1)
        {
            StatsManager.instance.speedMultiplier -= 1;
            StatsManager.instance.coins += speedMultiplierPrice;
        }
    }

    public void decreaseFocus()
    {
        if (StatsManager.instance.focusMultiplier > 0)
        {
            StatsManager.instance.focusMultiplier -= 1;
            StatsManager.instance.coins += focusMultiplierPrice;
        }
    }

}
