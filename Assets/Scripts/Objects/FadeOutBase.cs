using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutBase : MonoBehaviour
{
    public GameObject fadeObject;
    public Animator fadeAnimate;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        if (fadeObject != null)
        {
            fadeAnimate = fadeObject.GetComponentInChildren<Animator>();
        }
    }

    protected void FadeOut()
    {
        if (fadeObject != null)
        {
            fadeObject.SetActive(true);
        }
        if (fadeAnimate != null)
        {
            fadeAnimate.SetBool("IsFadeOut", true);
        }
        else
        {
            Debug.Log("No animator found for " + gameObject.name);
        }
    }
}
