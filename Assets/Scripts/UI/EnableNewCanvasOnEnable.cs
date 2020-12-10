using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableNewCanvasOnEnable : MonoBehaviour
{
    public Canvas newCanvas;
    public float delay = 3f;
    // Start is called before the first frame update
    void Awake()
    {
        if (newCanvas != null)
        {
            newCanvas.enabled = false;
            newCanvas.gameObject.SetActive(false);
        }
    }

    void OnEnable()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        if (newCanvas != null)
        {
            newCanvas.enabled = true;
            newCanvas.gameObject.SetActive(true);
        }
    }
}
