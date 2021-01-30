using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleControlScreenOnClick : MonoBehaviour
{
    public Canvas canvasToToggle;


    // Start is called before the first frame update
    void Start()
    {
        if(canvasToToggle != null)
        {
            canvasToToggle.enabled = false;
        }
        else
        {
            Debug.Log("No Canvas Attached!");
        }
    }

    public void OnClickToggle()
    {
        if(canvasToToggle != null)
        {
            ToggleCanvas();
        }
    }

    void ToggleCanvas()
    {
        if (canvasToToggle.enabled)
        {
            canvasToToggle.enabled = false;
        }
        else
        {
            canvasToToggle.enabled = true;
        }
    }
}
