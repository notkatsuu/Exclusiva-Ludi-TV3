using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamionMOvement : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float speed = 1f;
    private Vector3 direction;

    void Start()
    {
        float angle = 26f; // The angle in degrees
        float radians = angle * Mathf.Deg2Rad; // Convert the angle to radians

        // Calculate the direction vector
        direction = new Vector3(-Mathf.Cos(radians), Mathf.Sin(radians), 0);
        
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
