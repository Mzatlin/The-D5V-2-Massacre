using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour,IPause
{
    public Canvas pauseCanavs;
    public List<Canvas> subCanvases = new List<Canvas>();
    IPlayerState player => GetComponent<IPlayerState>();
    bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        if(pauseCanavs != null)
        {
            pauseCanavs.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null && !player.PlayerState.isDead)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                HandlePause();
            }
        }
    }

    void HandlePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            pauseCanavs.enabled = false;
            Cursor.visible = false;
            player.PlayerState.isPaused = false;
            DisableSubMenus();
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
            pauseCanavs.enabled = true;
            Cursor.visible = true;
            player.PlayerState.isPaused = true;
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.1f);
        HandlePause();
    }

    void DisableSubMenus()
    {
        if (subCanvases.Count > 0)
        {
            foreach (Canvas can in subCanvases)
            {
                can.enabled = false;
            }
        }
    }


    public void SetPause()
    {
        isPaused = false;
    }
}
