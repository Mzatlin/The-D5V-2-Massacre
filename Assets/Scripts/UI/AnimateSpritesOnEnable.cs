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

   void Awake()
    {
        image = GetComponentInChildren<Image>();
    }

    void OnEnable()
    {
        StartCoroutine(ManualAnimation());
    }


    public IEnumerator ManualAnimation()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            image.sprite = sprites[i];
            yield return new WaitForSeconds(animationSpeed);
        }
    }
}
