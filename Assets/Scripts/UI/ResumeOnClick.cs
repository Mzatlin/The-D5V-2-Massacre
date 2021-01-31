using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeOnClick : MonoBehaviour
{
    public Canvas pauseCanvas;
    public GameObject player;
    public PlayerStateSO playerState;
    public void Resume()
    {
        Time.timeScale = 1;
        pauseCanvas.enabled = false;
        Cursor.visible = false;

        if(player != null && playerState != null)
        {
            player.GetComponent<IPause>().SetPause();
            playerState.isPaused = false;
        }
    }
}
