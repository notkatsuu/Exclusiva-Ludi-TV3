using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAppearences : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] objects; // The objects to show and hide

    void Start()
    {
        StartCoroutine(ActivateObjectsRandomly());
    }

    IEnumerator ActivateObjectsRandomly()
    {
        List<GameObject> objectList = new List<GameObject>(objects); // Create a list from the array

        while (objectList.Count > 0) // While there are still objects in the list
        {
            int index = Random.Range(0, objectList.Count); // Get a random index

            GameObject obj = objectList[index]; // Get the object at the random index

            // If the object is not null, show it
            if (obj != null)
            {
                obj.SetActive(true);
            }

            yield return new WaitForSeconds(2f); // Wait for 2 seconds

            // If the object is not null, hide it
            if (obj != null)
            {
                obj.SetActive(false);
            }

            yield return new WaitForSeconds(2f);

            objectList.RemoveAt(index); // Remove the object from the list
        }
    }
}
