using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutOnPlay : MonoBehaviour
{
    public GameObject fadeObject;
    [SerializeField]
    Animator fadeAnimate;
    // Start is called before the first frame update
    void Awake()
    {
        if(fadeObject != null)
        {
            fadeAnimate = fadeObject.GetComponentInChildren<Animator>();
        }
    }

    public void OnFadeClick()
    {
        if(fadeObject != null)
        {
            fadeObject.SetActive(true);
        }
        if(fadeAnimate != null)
        {
            fadeAnimate.SetBool("IsFadeOut", true);
        }
        else
        {
            Debug.Log("No animator found for "+gameObject.name);
        }
    }
}
