using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public float startTime;

    void Awake()
    {
        startTime = Time.time;
    }

    public float getTime(){
        return startTime;
    }
}
