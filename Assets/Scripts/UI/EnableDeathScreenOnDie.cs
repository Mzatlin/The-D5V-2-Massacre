using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDeathScreenOnDie : MonoBehaviour
{
    public Canvas deathCanvas;
    IDie die => GetComponent<IDie>();
    public event Action OnCanvasActive = delegate { };
    // Start is called before the first frame update
    void Start()
    {
        if (deathCanvas != null)
        {
            deathCanvas.enabled = false;
            deathCanvas.gameObject.SetActive(false);
        }
        if (die != null)
        {
            die.OnDie += HandleDie;
        }
    }

    private void OnDestroy()
    {
        if (die != null)
        {
            die.OnDie -= HandleDie;
        }
    }

    private void HandleDie()
    {
        if (deathCanvas != null)
        {
            deathCanvas.enabled = true;
            deathCanvas.gameObject.SetActive(true);
        }
    }
}
