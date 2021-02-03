using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDeathScreenOnDie : HandleDeathBase
{
    public Canvas deathCanvas;
    public event Action OnCanvasActive = delegate { };
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if (deathCanvas != null)
        {
            deathCanvas.enabled = false;
            deathCanvas.gameObject.SetActive(false);
        }
    }


    protected override void HandleDie()
    {
        if (deathCanvas != null)
        {
            deathCanvas.enabled = true;
            deathCanvas.gameObject.SetActive(true);
        }
    }
}
