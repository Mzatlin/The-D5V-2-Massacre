using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeOnClick : MonoBehaviour
{
    public Canvas pauseCanvas;
    public GameObject player;
    public void Resume()
    {
        Time.timeScale = 1;
        pauseCanvas.enabled = false;
        Cursor.visible = false;
        player.GetComponent<IPause>().SetPause();
    }
}
