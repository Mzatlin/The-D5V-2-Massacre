using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateSpritesOnEnable : MonoBehaviour
{
    public Sprite[] sprites;
    public float animationSpeed;
    [SerializeField]
    private Image image;
    GameObject mainCamera;
    bool isPlaying = false;

   void Awake()
    {
        image = GetComponentInChildren<Image>();
        mainCamera = FindObjectOfType<Camera>().gameObject;
        
    }

    void OnEnable()
    {
        AkSoundEngine.PostEvent("Play_DeathTransition", mainCamera);
        StartCoroutine(ManualAnimation());
    }


    public IEnumerator ManualAnimation()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            image.sprite = sprites[i];
            yield return new WaitForSeconds(animationSpeed);
            if(i == sprites.Length - 1 && !isPlaying)
            {
                isPlaying = true;
                //GameObject mainCamera = FindObjectOfType<Camera>().gameObject;
                AkSoundEngine.PostEvent("Play_DeathMusic", mainCamera);
                Debug.Log("Triggered Death Music" + i);
            }
        }
    }
}
