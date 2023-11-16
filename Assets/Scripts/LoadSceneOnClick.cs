using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{


    public Animator animator;
    public float transitionDelayTime = 1.0f;
     public void LoadLevel(string name)
    {
        StartCoroutine(DelayLoadLevel(name));
    }

     IEnumerator DelayLoadLevel(int index)
    {
        animator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene(index);
    }




 
    void Awake()
    {
        animator = GameObject.Find("Fader").GetComponent<Animator>();
    }

  

    IEnumerator DelayLoadLevel(string name)
    {
        animator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene(name);
    }
}
