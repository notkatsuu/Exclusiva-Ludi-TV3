using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CountdownTimer : MonoBehaviour
{
    public int countdownTime = 30;

    public string sceneToLoad;
    private Text countdownText;

    void Start()
    {
        countdownText = GetComponent<Text>();
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    { yield return new WaitForSeconds(1f);
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownText.text = "0";


        SceneManager.LoadScene(sceneToLoad);


    }
}
